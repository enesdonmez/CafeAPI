using CafeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeAPI.Persistence.Configurations;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> entity)
    {
        entity.ToTable("MenuItems");
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Name)
              .IsRequired()
              .HasMaxLength(100)
              .HasColumnType("nvarchar(100)");

        entity.Property(e => e.Description)
              .HasMaxLength(500)
              .HasColumnType("nvarchar(500)");

        entity.Property(e => e.Price)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

        entity.Property(e => e.Image)
              .HasMaxLength(255)
              .HasColumnType("nvarchar(500)");

        entity.Property(e => e.IsAvailable)
              .HasDefaultValue(true);

        entity.HasOne(e => e.Category)
              .WithMany(c => c.MenuItems)
              .HasForeignKey(e => e.CategoryId)
              .OnDelete(DeleteBehavior.NoAction);

        entity.Property(e => e.CreatedAt)
              .HasColumnType("datetime")
              .IsRequired();
    }
}
