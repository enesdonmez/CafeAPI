using CafeAPI.Domain.Entities;
using CafeAPI.Persistence.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace CafeAPI.Persistence.Context;

public class AppDbContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<AppDbContext> _logger;

    public AppDbContext(DbContextOptions<AppDbContext> options , IHttpContextAccessor httpContextAccessor , ILogger<AppDbContext> logger) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    public DbSet<MenuItem> MenuItems { get; set; } 
    public DbSet<Category> Categories { get; set; } 
    public DbSet<Table> Tables { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<CafeInfo> CafeInfos { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var auditEntries = PrepareAuditEntries();
        var result = await base.SaveChangesAsync(cancellationToken);
        WriteAuditLogsToSeq(auditEntries);
        return result;
    }

    private List<AuditEntry> PrepareAuditEntries()
    {
        ChangeTracker.DetectChanges();
        var entries = new List<AuditEntry>();

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Unchanged || entry.State == EntityState.Detached)
                continue;

            var auditEntry = new AuditEntry
            {
                TableName = entry.Metadata.GetTableName(),
                Action = entry.State.ToString(),
                User = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Anonymous",
                IP = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
                Time = DateTime.UtcNow
            };

            foreach (var prop in entry.Properties)
            {
                var name = prop.Metadata.Name;

                if (entry.State == EntityState.Added)
                {
                    auditEntry.NewValues[name] = prop.CurrentValue;
                }
                else if (entry.State == EntityState.Modified && prop.IsModified)
                {
                    auditEntry.OldValues[name] = prop.OriginalValue;
                    auditEntry.NewValues[name] = prop.CurrentValue;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    auditEntry.OldValues[name] = prop.OriginalValue;
                }
            }

            entries.Add(auditEntry);
        }

        return entries;
    }

    private void WriteAuditLogsToSeq(List<AuditEntry> entries)
    {
        foreach (var entry in entries)
        {
            _logger.LogInformation("AUDIT | Table: {Table} | Action: {Action} | User: {User} | IP: {IP} | Old: {@Old} | New: {@New} | Time: {Time}",
                entry.TableName,
                entry.Action,
                entry.User,
                entry.IP,
                entry.OldValues,
                entry.NewValues,
                entry.Time
            );
        }
    }

}
