using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenHung.DAL.Models;

public class Category
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string FishImage { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}

