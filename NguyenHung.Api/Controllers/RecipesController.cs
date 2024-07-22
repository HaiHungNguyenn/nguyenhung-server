using Microsoft.AspNetCore.Mvc;
using NguyenHung.Api.Controllers.BaseController;
using NguyenHung.Service.Interfaces;
using NguyenHung.Service.WebRequest;

namespace NguyenHung.Api.Controllers;

public class RecipesController : BaseApiController
{
    private readonly IRecipeService _recipeService;

    public RecipesController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return await ExecuteServiceLogic(async () => await _recipeService.GetAllAsync().ConfigureAwait(false))
            .ConfigureAwait(false);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRecipeByIdAsync(Guid id)
    {
        return await ExecuteServiceLogic(async () => await _recipeService.GetByIdAsync(id).ConfigureAwait(false))
            .ConfigureAwait(false);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecipeAsync([FromForm] CreateRecipeRequest request)
    {
        return await ExecuteServiceLogic(async () => await _recipeService.CreateAsync(request).ConfigureAwait(false))
            .ConfigureAwait(false);
    }
}
