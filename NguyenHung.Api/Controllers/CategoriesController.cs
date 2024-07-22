using Microsoft.AspNetCore.Mvc;
using NguyenHung.Api.Controllers.BaseController;
using NguyenHung.Service.Interfaces;
using NguyenHung.Service.WebRequest;

namespace NguyenHung.Api.Controllers;

public class CategoriesController : BaseApiController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCategoriesAsync()
    {
        return await ExecuteServiceLogic(async () => await _categoryService.GetAllAsync().ConfigureAwait(false)).ConfigureAwait(false);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCategoryByIdAsync(Guid id)
    {
        return await ExecuteServiceLogic(async() => await _categoryService.GetByIdAsync(id).ConfigureAwait(false))
            .ConfigureAwait(false);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync([FromForm]CreateCategoryRequest request)
    {
        return await ExecuteServiceLogic(async () => await _categoryService.CreateAsync(request).ConfigureAwait(false))
            .ConfigureAwait(false);
    }
}