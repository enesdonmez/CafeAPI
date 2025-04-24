using CafeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeAPI.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> entity)
    {
        entity.ToTable("Categories");
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Name)
              .IsRequired()
              .HasMaxLength(50)
              .HasColumnType("nvarchar(50)");

        entity.HasMany(e => e.MenuItems)
              .WithOne(m => m.Category)
              .HasForeignKey(m => m.CategoryId)
              .OnDelete(DeleteBehavior.NoAction);

        entity.Property(e => e.CreatedAt)
          .HasColumnType("datetime")
          .IsRequired();
    }
}
