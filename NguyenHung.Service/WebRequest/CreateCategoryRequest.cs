using Microsoft.AspNetCore.Http;

namespace NguyenHung.Service.WebRequest;

public class CreateCategoryRequest
{
    public required string Name { get; set; }

    public required IFormFile Images { get; set; }
}