using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CafeAPI.Persistence.Identity
{
    public class AppIdentityContext : IdentityDbContext<AppIdentityUser, AppIdentityRole, string>
    {
        public AppIdentityContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppIdentityUser>(b =>
            {
                b.ToTable("Users");
            });
            builder.Entity<AppIdentityRole>(b =>
            {
                b.ToTable("Roles");
            });
        }
    }
}
