using AutoMapper;
using NguyenHung.DAL.Dtos;
using NguyenHung.DAL.Models;

namespace NguyenHung.Service.AutoMapper;

public class RecipeProfile : Profile
{
    public RecipeProfile()
    {
        CreateMap<Recipe, DtoRecipe>();
    }   
}