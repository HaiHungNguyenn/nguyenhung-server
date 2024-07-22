using NguyenHung.Service.Models.Common;
using NguyenHung.Service.WebRequest;

namespace NguyenHung.Service.Interfaces;

public interface ICookingWearService
{
    Task<ServiceActionResult> GetAllAsync();
    Task<ServiceActionResult> GetByIdAsync(Guid id);
    Task<ServiceActionResult> CreateAsync(CreateCookingWearRequest request);
    Task<ServiceActionResult> UpdateAsync();
    Task<ServiceActionResult> DeleteAsync();
}