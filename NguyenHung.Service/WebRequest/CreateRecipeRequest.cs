using Microsoft.AspNetCore.Http;

namespace NguyenHung.Service.WebRequest;

public class CreateRecipeRequest
{
    public Guid CategoryId { get; set; }

    public List<Guid> CookingWearIds { get; set; } = new();
    public required string Title { get; set; }
    public float Duration { get; set; }
    public float Portion { get; set; }
    public List<string> Ingredients { get; set; } = new();
    public List<string> Instructions { get; set; } = new();
    public IFormFile RecipeImage { get; set; } = null!;
}