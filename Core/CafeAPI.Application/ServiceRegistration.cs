using CafeAPI.Application.Dtos.CategoryDtos;
using CafeAPI.Application.Dtos.MenuItemDtos;
using CafeAPI.Application.Dtos.OrderDtos;
using CafeAPI.Application.Dtos.OrderItemDtos;
using CafeAPI.Application.Dtos.TableDtos;
using CafeAPI.Application.Dtos.UserDtos;
using CafeAPI.Application.Helpers;
using CafeAPI.Application.Mapping;
using CafeAPI.Application.Services.Abstract;
using CafeAPI.Application.Services.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CafeAPI.Application;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection serviceCollection) 
    { 
        serviceCollection.AddAutoMapper(typeof(GeneralMapping));
        serviceCollection.AddScoped<ICategoryService, CategoryService>();
        serviceCollection.AddScoped<IMenuItemService, MenuItemService>();
        serviceCollection.AddScoped<ITableService, TableService>();
        serviceCollection.AddScoped<IOrderService, OrderService>();
        serviceCollection.AddScoped<IOrderItemItemService, OrderItemService>();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddTransient<TokenHelper>();
        serviceCollection.AddValidatorsFromAssemblyContaining<CreateCategoryDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<UpdateCategoryDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<CreateMenuItemDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<UpdateMenuItemDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<CreateTableDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<UpdateTableDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<CreateOrderItemDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<UpdateOrderItemDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<CreateOrderDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<UpdateOrderDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<RegisterDto>();

    }
}
