using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NguyenHung.DAL.Models;

namespace NguyenHung.DAL.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Title).IsRequired()
            .HasMaxLength(255);
        builder.Property(r => r.Duration);
        builder.Property(r => r.Portion);
        builder.Property(r => r.Ingredient).IsRequired().HasMaxLength(-1);
        builder.Property(r => r.Instruction).IsRequired().HasMaxLength(-1);
        builder.Property(r => r.RecipeImage).IsRequired().HasMaxLength(-1);
    }
}