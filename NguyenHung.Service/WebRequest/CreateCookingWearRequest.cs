using Microsoft.AspNetCore.Http;

namespace NguyenHung.Service.WebRequest;

public class CreateCookingWearRequest
{
    public required string Name { get; set; }
    public IFormFile CookingWearImage { get; set; } = null!;
}