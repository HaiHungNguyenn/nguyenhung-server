using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NguyenHung.DAL.Models;

namespace NguyenHung.DAL.Configurations;

public class RecipeCookingWearConfiguration : IEntityTypeConfiguration<RecipeCookingWear>
{
    public void Configure(EntityTypeBuilder<RecipeCookingWear> builder)
    {
        builder.HasKey(rcw => new { rcw.RecipeId, rcw.CookingWearId });
        
        //relationship
        // builder.HasOne<Recipe>()
        //     .WithMany(r => r.RecipeCookingWears)
        //     .HasForeignKey(rcw => rcw.RecipeId)
        //     .IsRequired();
        //
        // builder.HasOne<CookingWear>()
        //     .WithMany(cw => cw.RecipeCookingWears)
        //     .HasForeignKey(rcw => rcw.CookingWearId)
        //     .IsRequired();
    }
}