using CafeAPI.Application.Dtos.CafeInfoDtos;
using CafeAPI.Application.Dtos.CategoryDtos;
using CafeAPI.Application.Dtos.MenuItemDtos;
using CafeAPI.Application.Dtos.OrderDtos;
using CafeAPI.Application.Dtos.OrderItemDtos;
using CafeAPI.Application.Dtos.ReservationDtos;
using CafeAPI.Application.Dtos.ReviewDtos;
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
        serviceCollection.AddScoped<IRoleService, RoleService>();
        serviceCollection.AddScoped<ICafeInfoService, CafeInfoService>();
        serviceCollection.AddScoped<IReviewService, ReviewService>();
        serviceCollection.AddScoped<IReservationService, ReservationService>();
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
        serviceCollection.AddValidatorsFromAssemblyContaining<CreateCafeInfoDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<UpdateCafeInfoDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<CreateReviewDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<UpdateReviewDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<CreateReservationDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<UpdateReservationDto>();

    }
}
