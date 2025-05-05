using AutoMapper;
using CafeAPI.Application.Dtos.CategoryDtos;
using CafeAPI.Application.Dtos.MenuItemDtos;
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

        CreateMap<MenuItem, ResultMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, CreateMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, UpdateMenuItemDto>().ReverseMap();
        CreateMap<MenuItem, DetailMenuItemDto>().ReverseMap();

        CreateMap<Table, ResultTableDto>().ReverseMap();
        CreateMap<Table, CreateTableDto>().ReverseMap();
        CreateMap<Table, UpdateTableDto>().ReverseMap();
        CreateMap<Table, DetailTableDto>().ReverseMap();
    }
}
