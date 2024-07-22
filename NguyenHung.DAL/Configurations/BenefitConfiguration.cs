using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NguyenHung.DAL.Models;

namespace NguyenHung.DAL.Configurations;

public class BenefitConfiguration : IEntityTypeConfiguration<Benefit>
{
    public void Configure(EntityTypeBuilder<Benefit> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Description).IsRequired();
        builder.Property(b => b.Title).IsRequired();
        builder.Property(b => b.BenefitImage).IsRequired(false).HasMaxLength(-1);
        
        //relationship
        builder.HasOne<Product>()
            .WithMany(p => p.Benefits)
            .HasForeignKey(b => b.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .IsRequired();
    }
}