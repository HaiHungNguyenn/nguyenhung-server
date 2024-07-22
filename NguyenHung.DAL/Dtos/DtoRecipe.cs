using System.Collections;

namespace NguyenHung.DAL.Dtos;

public class DtoRecipe
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public float Duration { get; set; }
    public float Portion { get; set; }
    public required string Ingredient { get; set; } 
    public required string Instruction { get; set; } 
    public required string RecipeImage { get; set; }
    public ICollection<DtoRecipeCookingWear> RecipeCookingWears { get; set; } = new List<DtoRecipeCookingWear>();
}

public sealed class DtoRecipeCookingWear
{
    public Guid RecipeId { get; set; }
    public Guid CookingWearId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
