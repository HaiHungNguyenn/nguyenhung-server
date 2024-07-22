using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenHung.DAL.Models;

public class RecipeCookingWear
{
    public Guid RecipeId { get; set; }
    public Guid CookingWearId { get; set; }
    public Recipe Recipe { get; set; } = null!;     
    public CookingWear CookingWear { get; set; } = null!;
    public bool IsActive { get; set; } = true;
}