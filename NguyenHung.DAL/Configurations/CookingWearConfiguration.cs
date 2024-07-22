using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NguyenHung.DAL.Models;

namespace NguyenHung.DAL.Configurations;

public class CookingWearConfiguration : IEntityTypeConfiguration<CookingWear>
{
    public void Configure(EntityTypeBuilder<CookingWear> builder)
    {
        builder.HasKey(ck => ck.Id);
        builder.Property(ck => ck.Name).IsRequired().HasMaxLength(255);
        builder.Property(ck => ck.ImageUrl).IsRequired().HasMaxLength(-1);
    }
}