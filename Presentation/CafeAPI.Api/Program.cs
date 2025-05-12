using CafeAPI.Application;
using CafeAPI.Application.Interfaces;
using CafeAPI.Persistence;
using CafeAPI.Persistence.Repository;
using Scalar.AspNetCore;

namespace CafeAPI.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddPersistenceServices(builder.Configuration);
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped<ITableRepository,TableRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddApplicationServices();
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference(options =>
            {
                options.WithTitle("Cafe API")
                       .WithTheme(ScalarTheme.Saturn)
                       .WithDefaultHttpClient(ScalarTarget.Http, ScalarClient.Http11);
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
