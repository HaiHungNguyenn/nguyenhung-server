using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenHung.DAL.Models;

public class Benefit
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string BenefitImage { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}