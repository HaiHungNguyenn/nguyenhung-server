using AutoMapper;
using NguyenHung.DAL.Dtos;
using NguyenHung.DAL.Models;

namespace NguyenHung.Service.AutoMapper;

public class NutrientProfile : Profile
{
    public NutrientProfile()
    {
        CreateMap<Nutrient, DtoNutrient>();
    }
}