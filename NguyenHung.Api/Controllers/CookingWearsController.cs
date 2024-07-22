using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using NguyenHung.Api.Controllers.BaseController;
using NguyenHung.Service.Interfaces;
using NguyenHung.Service.WebRequest;

namespace NguyenHung.Api.Controllers;

public class CookingWearsController : BaseApiController
{
    private readonly ICookingWearService _cookingWearService;

    public CookingWearsController(ICookingWearService cookingWearService)
    {
        _cookingWearService = cookingWearService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return await ExecuteServiceLogic(async () => await _cookingWearService.GetAllAsync().ConfigureAwait(false))
            .ConfigureAwait(false);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        return await ExecuteServiceLogic(async () => await _cookingWearService.GetByIdAsync(id).ConfigureAwait(false))
            .ConfigureAwait(false);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCookingWearAsync([FromForm] CreateCookingWearRequest request)
    {
        return await ExecuteServiceLogic(async () =>
                await _cookingWearService.CreateAsync(request).ConfigureAwait(false))
            .ConfigureAwait(false);
    }
}