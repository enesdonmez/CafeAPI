using AutoMapper;
using CafeAPI.Application.Dtos.CafeInfoDtos;
using CafeAPI.Application.Dtos.CategoryDtos;
using CafeAPI.Application.Dtos.MenuItemDtos;
using CafeAPI.Application.Dtos.OrderDtos;
using CafeAPI.Application.Dtos.OrderItemDtos;
using CafeAPI.Application.Dtos.TableDtos;
using CafeAPI.Domain.Entities;

namespace CafeAPI.Application.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, DetailCategoryDto>().ReverseMap();
        CreateMap<Category, ResultCategoryWithMenuItemDto>().ReverseMap();

        CreateMap<MenuItem, ResultMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, CreateMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, UpdateMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, DetailMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, CategoriesMenuItemDto>().ReverseMap();

        CreateMap<Table, ResultTableDto>().ReverseMap();
        CreateMap<Table, CreateTableDto>().ReverseMap();
        CreateMap<Table, UpdateTableDto>().ReverseMap();
        CreateMap<Table, DetailTableDto>().ReverseMap();

        CreateMap<Order, ResultOrderDto>().ReverseMap();
        CreateMap<Order, CreateOrderDto>().ReverseMap();
        CreateMap<Order, UpdateOrderDto>().ReverseMap();
        CreateMap<Order, DetailOrderDto>().ReverseMap();

        CreateMap<OrderItem, ResultOrderItemDto>().ReverseMap();
        CreateMap<OrderItem, CreateOrderItemDto>().ReverseMap();
        CreateMap<OrderItem, UpdateOrderItemDto>().ReverseMap();
        CreateMap<OrderItem, DetailOrderItemDto>().ReverseMap();

        CreateMap<CafeInfo, ResultCafeInfoDto>().ReverseMap();
        CreateMap<CafeInfo, UpdateCafeInfoDto>().ReverseMap();
        CreateMap<CafeInfo, CreateCafeInfoDto>().ReverseMap();
        CreateMap<CafeInfo, DetailCafeInfoDto>().ReverseMap();

    }
}
