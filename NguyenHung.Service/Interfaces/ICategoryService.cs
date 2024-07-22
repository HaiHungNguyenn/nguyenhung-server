using NguyenHung.Service.Models.Common;
using NguyenHung.Service.WebRequest;

namespace NguyenHung.Service.Interfaces;

public interface ICategoryService
{
    Task<ServiceActionResult> GetAllAsync();
    Task<ServiceActionResult> GetByIdAsync(Guid id);
    Task<ServiceActionResult> CreateAsync(CreateCategoryRequest request);
    Task<ServiceActionResult> UpdateAsync();
    Task<ServiceActionResult> DeleteAsync();
}