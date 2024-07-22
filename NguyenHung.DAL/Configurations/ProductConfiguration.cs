using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NguyenHung.DAL.Models;

namespace NguyenHung.DAL.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(-1);
        builder.Property(p => p.Ingredient).IsRequired().HasMaxLength(-1);
        
        //relationship
        // builder.HasOne<Category>()
        //     .WithMany(c => c.Products)
        //     .HasForeignKey(p => p.CategoryId)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .IsRequired();
    }
}