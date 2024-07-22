using AutoMapper;
using NguyenHung.Common.Attributes;
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
public class CookingWearService : ICookingWearService
{
    private readonly ICookingWearRepository _cookingWearRepository;
    private readonly IFileService _fileService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CookingWearService(ICookingWearRepository cookingWearRepository, IFileService fileService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _cookingWearRepository = cookingWearRepository;
        _fileService = fileService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ServiceActionResult> GetAllAsync()
    {
        var cookingWears = await _cookingWearRepository.GetAllAsync();
        return new ServiceActionResult()
        {
            Data = _mapper.ProjectTo<DtoCookingWear>(cookingWears)
        };
    }

    public async Task<ServiceActionResult> GetByIdAsync(Guid id)
    {
        var cookingWear = await _cookingWearRepository.GetAsync(cw => cw.Id == id);
        return new ServiceActionResult()
        {
            Data = _mapper.Map<DtoCookingWear>(cookingWear)
        };
    }

    public async Task<ServiceActionResult> CreateAsync(CreateCookingWearRequest request)
    {
        var imageUrl = await _fileService.UploadFile(request.CookingWearImage);
        var newCookingWear = new CookingWear()
        {
            Name = request.Name,
            ImageUrl = imageUrl
        };
        await _cookingWearRepository.AddAsync(newCookingWear);
        await _unitOfWork.CommitAsync();
        return new ServiceActionResult()
        {
            Data = _mapper.Map<DtoCookingWear>(newCookingWear)
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