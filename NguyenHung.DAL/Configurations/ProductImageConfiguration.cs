using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NguyenHung.DAL.Models;

namespace NguyenHung.DAL.Configurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(pi => pi.Id);
        builder.Property(pi => pi.ImageUrl).IsRequired().HasMaxLength(-1);
        
        //relationship
        // builder.HasOne<Product>()
        //     .WithMany(p => p.ProductImages)
        //     .HasForeignKey(pi => pi.ProductId)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .IsRequired();
    }
}