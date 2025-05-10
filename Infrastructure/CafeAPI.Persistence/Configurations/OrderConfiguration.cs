using CafeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeAPI.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)
    {
        entity.ToTable("Orders");
        entity.HasKey(o => o.Id);
        entity.Property(o => o.TableId).IsRequired();
        entity.Property(o => o.TotalPrice).HasColumnType("decimal(18,2)");
        entity.Property(o => o.CreatedAt).IsRequired().HasColumnType("Datetime");
        entity.Property(o => o.Status).IsRequired().HasColumnType("nvarchar(100)");
        entity.HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

