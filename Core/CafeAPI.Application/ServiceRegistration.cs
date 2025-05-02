using CafeAPI.Application.Dtos.CategoryDtos;
using CafeAPI.Application.Dtos.MenuItemDtos;
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
        serviceCollection.AddValidatorsFromAssemblyContaining<CreateCategoryDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<UpdateCategoryDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<CreateMenuItemDto>();
        serviceCollection.AddValidatorsFromAssemblyContaining<UpdateMenuItemDto>();
    }
}
