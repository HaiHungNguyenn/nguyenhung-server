using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
public class ProductService : IProductService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;
    private readonly IFileService _fileService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public ProductService(IProductRepository productRepository, IFileService fileService, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
        _fileService = fileService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ServiceActionResult> GetAllAsync()
    {
        var products = (await _productRepository.FindAsync(x => x.IsActive))
            .Include(p => p.Nutrients)
            .Include(p => p.Benefits)
            .OrderBy(p => p.SizeType);
        return new ServiceActionResult()
        {
            Data =  _mapper.ProjectTo<DtoProduct>(products)
        };
    }

    public async Task<ServiceActionResult> GetByIdAsync(Guid id)
    {
        var product = (await _productRepository.FindAsync(x => x.Id == id && x.IsActive))
            .Include(p => p.Category)
            .Include(p => p.Nutrients)
            .Include(p => p.Benefits)
            .Include(p => p.ProductImages)
            .FirstOrDefault() ?? throw new NotFoundException($"Not Found Product {id}");
        return new ServiceActionResult()
        {
            Data = _mapper.Map<DtoProduct>(product)
        };
    }

    public async Task<ServiceActionResult> CreateAsync(CreateProductRequest request)
    {
        var isCategoryExist = (await _categoryRepository.GetAllAsync()).Any(c => c.Id == request.CategoryId && c.IsActive);
        if (isCategoryExist is false)
            throw new NotFoundException($"Not found category {request.CategoryId}.");
        
        var ingredient = StringInterpolationHelper.JoinList(request.Ingredients.ToList());
        var productImageUrls = await _fileService.GetUrlAfterUploadingFile(request.ProductImages.ToList());
        var productImages = productImageUrls.Select(url => new ProductImage()
        {
            ImageUrl = url
        }).ToList();
        var nutrients = DeserializeNutrients(request.NutrientsJson);
        var benefits = DeserializeBenefits(request.BenefitsJson);
        
        var newProduct = new Product
        {
            Name = request.Name,
            Ingredient = ingredient,
            Description = request.Description,
            CategoryId = request.CategoryId,
            ProductImages = productImages,
            Nutrients = nutrients,
            Benefits = benefits,
            SizeType = request.SizeType
        };
        
        await _productRepository.AddAsync(newProduct);
        await _unitOfWork.CommitAsync();

        return new ServiceActionResult()
        {
            Data = _mapper.Map<DtoProduct>(newProduct),
            StatusCode = StatusCodes.Status201Created
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

    private static List<Nutrient> DeserializeNutrients(string nutrientsJson)
    {
        var deserializedNutrients = JsonConvert.DeserializeObject<List<CreateNutrientRequest>>(nutrientsJson) 
                                    ?? throw new BadRequestException("Can not serialize the nutrient json.");
        var nutrients = deserializedNutrients.Select(nu => new Nutrient()
        {
            Name = nu.Name,
            Weight = nu.Weight,
            Percentage = nu.Percentage
        }).ToList();
        return nutrients;
    }

    private static List<Benefit> DeserializeBenefits(string benefitsJson)
    {
        var deserializeBenefits = JsonConvert.DeserializeObject<List<CreateBenefitRequest>>(benefitsJson)
                                  ?? throw new BadRequestException("Can not serialize the benefit json.");
        var benefits = deserializeBenefits.Select(be => new Benefit()
        {
            Title = be.Title,
            Description = be.Description,
            BenefitImage = be.BenefitImage
        }).ToList();
        return benefits;
    }
}