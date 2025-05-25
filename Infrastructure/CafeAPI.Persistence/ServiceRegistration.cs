using CafeAPI.Persistence.Context;
using CafeAPI.Persistence.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CafeAPI.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("CafeDbConnection")));

        serviceCollection.AddDbContext<AppIdentityContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CafeDbConnection")));

        serviceCollection.AddIdentity<AppIdentityUser, AppIdentityRole>(o =>
        {
            o.User.RequireUniqueEmail = true;
            o.Password.RequireDigit = true;
            o.Password.RequiredLength = 6;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
        })
            .AddEntityFrameworkStores<AppIdentityContext>()
            .AddDefaultTokenProviders();
    }
}
