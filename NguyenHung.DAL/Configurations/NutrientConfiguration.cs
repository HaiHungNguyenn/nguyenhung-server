using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NguyenHung.DAL.Models;

namespace NguyenHung.DAL.Configurations;

public class NutrientConfiguration : IEntityTypeConfiguration<Nutrient>
{
    public void Configure(EntityTypeBuilder<Nutrient> builder)
    {
        builder.HasKey(n => n.Id);
        builder.Property(n => n.Name).IsRequired();
        builder.Property(n => n.Percentage).IsRequired();
        builder.Property(n => n.Weight).IsRequired();
        
        //relationship
        // builder.HasOne<Product>()
        //     .WithMany(p => p.Nutrients)
        //     .HasForeignKey(n => n.ProductId)
        //     .OnDelete(DeleteBehavior.ClientSetNull)
        //     .IsRequired();
    }
}