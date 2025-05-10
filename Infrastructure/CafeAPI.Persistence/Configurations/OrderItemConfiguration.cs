using CafeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeAPI.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> entity)
    {
        entity.ToTable("OrderItems");
        entity.HasKey(e => e.Id);
        entity.Property(e => e.OrderId)
              .IsRequired()
              .HasColumnType("int");
        entity.Property(e => e.MenuItemId)
              .IsRequired()
              .HasColumnType("int");
        entity.Property(e => e.Quantity)
              .IsRequired()
              .HasColumnType("int");
        entity.Property(e => e.Price)
              .IsRequired()
              .HasColumnType("decimal(18,2)");
        entity.Property(e => e.CreatedAt)
              .IsRequired()
              .HasColumnType("datetime");
              

    }
}
