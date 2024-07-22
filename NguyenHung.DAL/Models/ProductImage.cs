namespace NguyenHung.DAL.Models;

public class ProductImage
{
    public Guid Id { get; set; }
    public required string ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
}