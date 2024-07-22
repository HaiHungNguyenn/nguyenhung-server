using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenHung.DAL.Models;

public class Nutrient
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public float Weight { get; set; }
    public float Percentage { get; set; }
    public bool IsActive { get; set; } = true;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}