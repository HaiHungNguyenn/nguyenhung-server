using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenHung.DAL.Models;

public class CookingWear
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<RecipeCookingWear> RecipeCookingWears { get; set; } = new List<RecipeCookingWear>();
}