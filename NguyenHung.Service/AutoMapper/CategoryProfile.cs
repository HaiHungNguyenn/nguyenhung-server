using AutoMapper;
using NguyenHung.DAL.Dtos;
using NguyenHung.DAL.Models;

namespace NguyenHung.Service.AutoMapper;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, DtoCategory>();
    }
}