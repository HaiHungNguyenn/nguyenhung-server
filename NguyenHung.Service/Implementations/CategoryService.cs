using AutoMapper;
using NguyenHung.Common.Attributes;
using NguyenHung.Common.Exceptions;
using NguyenHung.DAL.Interfaces;
using NguyenHung.DAL.Interfaces.BaseInterface;
using NguyenHung.DAL.Models;
using NguyenHung.Service.Interfaces;
using NguyenHung.Service.Interfaces.Base;
using NguyenHung.Service.Models.Common;
using NguyenHung.Service.WebRequest;
using  Microsoft.AspNetCore.Http;
using NguyenHung.DAL.Dtos;


namespace NguyenHung.Service.Implementations;
[ServiceRegister]
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IFileService _fileService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IFileService fileService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _fileService = fileService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<ServiceActionResult> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return new ServiceActionResult()
        {
            Data = categories
        };
    }

    public async Task<ServiceActionResult> GetByIdAsync(Guid id)
    {
        var category = await _categoryRepository.GetAsync(cate => cate.Id == id && cate.IsActive) ?? throw new NotFoundException($"Not found categories ID: {id}");
        return new ServiceActionResult()
        {
            Data = category
        };
    }

    public async Task<ServiceActionResult> CreateAsync(CreateCategoryRequest request)
    {
        if ((await _categoryRepository.GetAllAsync()).Any(x => x.Name.Equals(request.Name)&& x.IsActive))
            throw new BadRequestException($"Product category name {request.Name} is already exist.");
        var imageUrl = await _fileService.UploadFile(request.Images);
        var category = new Category {Name = request.Name, FishImage = imageUrl};
        await _categoryRepository.AddAsync(category);
        await _unitOfWork.CommitAsync();
        return new ServiceActionResult()
        {
            Data = _mapper.Map<DtoCategory>(category),
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
}