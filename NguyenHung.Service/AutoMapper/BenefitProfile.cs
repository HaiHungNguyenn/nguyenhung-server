using AutoMapper;
using NguyenHung.DAL.Dtos;
using NguyenHung.DAL.Models;

namespace NguyenHung.Service.AutoMapper;

public class BenefitProfile : Profile
{
    public BenefitProfile()
    {
        CreateMap<Benefit, DtoBenefit>();
    }
}