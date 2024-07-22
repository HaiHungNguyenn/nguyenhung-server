using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using NguyenHung.Api.Controllers.BaseController;
using NguyenHung.Service.Interfaces;
using NguyenHung.Service.WebRequest;

namespace NguyenHung.Api.Controllers;

public class ProductsController : BaseApiController
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync()
    {
        return await ExecuteServiceLogic(async () => await _productService.GetAllAsync().ConfigureAwait(false))
            .ConfigureAwait(false);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductByIdAsync(Guid id)
    {
        return await ExecuteServiceLogic(async () => await _productService.GetByIdAsync(id).ConfigureAwait(false))
            .ConfigureAwait(false);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync([FromForm]CreateProductRequest request)
    {
        return await ExecuteServiceLogic(async () => await _productService.CreateAsync(request).ConfigureAwait(false))
            .ConfigureAwait(false);
    }
}