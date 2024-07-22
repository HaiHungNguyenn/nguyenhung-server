using AutoMapper;
using NguyenHung.DAL.Dtos;
using NguyenHung.DAL.Models;

namespace NguyenHung.Service.AutoMapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, DtoProduct>()
            .ForMember(dto => dto.CategoryName, opt => opt.MapFrom(p => p.Category.Name))
            .ForMember(dto => dto.FishImage, opt => opt.MapFrom(p => p.Category.FishImage));
        CreateMap<ProductImage, DtoProductImage>();
    }
}