using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenHung.DAL.Models;

public class Recipe
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public float Duration { get; set; }
    public float Portion { get; set; }
    public required string Ingredient { get; set; }
    public required string Instruction { get; set; }
    
    public required string RecipeImage { get; set; }  
    public bool IsActive { get; set; } = true;
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public ICollection<RecipeCookingWear> RecipeCookingWears { get; set; } = new List<RecipeCookingWear>();
}