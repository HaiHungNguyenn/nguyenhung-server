using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NguyenHung.Common.Attributes;
using NguyenHung.Common.Exceptions;
using NguyenHung.Common.Helpers;
using NguyenHung.DAL.Dtos;
using NguyenHung.DAL.Interfaces;
using NguyenHung.DAL.Interfaces.BaseInterface;
using NguyenHung.DAL.Models;
using NguyenHung.Service.Interfaces;
using NguyenHung.Service.Interfaces.Base;
using NguyenHung.Service.Models.Common;
using NguyenHung.Service.WebRequest;

namespace NguyenHung.Service.Implementations;
[ServiceRegister]
public class RecipeService : IRecipeService
{
    private readonly ICookingWearRepository _cookingWearRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IRecipeRepository _recipeRepository;
    private readonly IFileService _fileService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RecipeService(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository, IFileService fileService, ICookingWearRepository cookingWearRepository)
    {
        _cookingWearRepository = cookingWearRepository;
        _categoryRepository = categoryRepository;
        _recipeRepository = recipeRepository;
        _fileService = fileService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ServiceActionResult> GetAllAsync()
    {
        var recipes = (await _recipeRepository.GetAllAsync())
            .Include(r => r.RecipeCookingWears)
            .ThenInclude(rcw => rcw.CookingWear);
        return new ServiceActionResult()
        {
            Data = _mapper.ProjectTo<DtoRecipe>(recipes)
        };
    }

    public async Task<ServiceActionResult> GetByIdAsync(Guid id)
    {
        var recipe = (await _recipeRepository.FindAsync(r => r.Id == id))
                     .Include(r => r.RecipeCookingWears)
                     .ThenInclude(rcw => rcw.CookingWear)
                     .FirstOrDefault()
                     ?? throw new NotFoundException($"Not Found Recipe {id}.");
        return new ServiceActionResult()
        {
            Data = _mapper.Map<DtoRecipe>(recipe)
        };
    }

    public async Task<ServiceActionResult> CreateAsync(CreateRecipeRequest request)
    {
        var isExistCategory = ((await _categoryRepository.GetAllAsync()).Any(c => c.Id == request.CategoryId));
        if (isExistCategory is false)
            throw new NotFoundException($"Not found category {request.CategoryId}.");
        
        foreach (var requestCookingWearId in request.CookingWearIds)
        {
            if (!(await _cookingWearRepository.GetAllAsync()).Any(x => x.Id == requestCookingWearId))
                throw new NotFoundException($"Not found cooking wear {requestCookingWearId}");
        }
        
        var ingredient = StringInterpolationHelper.JoinList(request.Ingredients);
        var instruction = StringInterpolationHelper.JoinList(request.Instructions);
        var imageUrl = (await _fileService.UploadFile(request.RecipeImage));

        var newRecipe = new Recipe
        {
            CategoryId = request.CategoryId,
            Title = request.Title,
            Ingredient = ingredient,
            Instruction = instruction,
            Duration = request.Duration,
            Portion = request.Portion,
            RecipeImage = imageUrl
        };

        await _recipeRepository.AddAsync(newRecipe);
        await _unitOfWork.CommitAsync();

        var cookingWears = request.CookingWearIds.Select(id => new RecipeCookingWear()
        {
            RecipeId = newRecipe.Id,
            CookingWearId = id
        }).ToList();
        
        newRecipe.RecipeCookingWears = cookingWears;
        await _recipeRepository.UpdateAsync(newRecipe);
        await _unitOfWork.CommitAsync();
        
        return new ServiceActionResult()
        {
            StatusCode = StatusCodes.Status201Created,
            Data = _mapper.Map<DtoRecipe>(newRecipe)
        };
    }

    public Task<ServiceActionResult> UpdateAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceActionResult> DeleteAsync()
    {
        throw new NotImplementedException();
    }
}