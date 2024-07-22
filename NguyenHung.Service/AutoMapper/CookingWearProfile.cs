using AutoMapper;
using NguyenHung.DAL.Dtos;
using NguyenHung.DAL.Models;

namespace NguyenHung.Service.AutoMapper;

public class CookingWearProfile : Profile
{
    public CookingWearProfile()
    {
        CreateMap<CookingWear, DtoCookingWear>();
        CreateMap<RecipeCookingWear, DtoRecipeCookingWear>()
            .ForMember(dto => dto.ImageUrl, 
                opt => opt.MapFrom(rcw => rcw.CookingWear.ImageUrl))
            .ForMember(dto => dto.Name,
                opt => opt.MapFrom(rcw => rcw.CookingWear.Name));
    }    
}