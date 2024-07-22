using Microsoft.AspNetCore.Http;

namespace NguyenHung.Service.WebRequest;

public class CreateProductRequest
{
    public Guid CategoryId { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public ICollection<string> Ingredients { get; set; } = new List<string>();
    public required string NutrientsJson { get; set; } 
    public required string BenefitsJson { get; set; } 
    public int SizeType { get; set; }
    public ICollection<IFormFile> ProductImages { get; set; } = new List<IFormFile>();
}

public sealed record CreateNutrientRequest
{
    public required string Name { get; set; }
    public float Weight { get; set; }
    public float Percentage { get; set; }
}

public sealed record CreateBenefitRequest
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string BenefitImage { get; set; } = "https://nguyenhung.blob.core.windows.net/nguyenhungstorage/eye.png";
}