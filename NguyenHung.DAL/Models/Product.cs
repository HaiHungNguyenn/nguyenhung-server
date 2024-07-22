using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenHung.DAL.Models;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Ingredient { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public int? SizeType { get; set; }
    
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public ICollection<Nutrient> Nutrients { get; set; }= new List<Nutrient>();
    public ICollection<Benefit> Benefits { get; set; }= new List<Benefit>();
}