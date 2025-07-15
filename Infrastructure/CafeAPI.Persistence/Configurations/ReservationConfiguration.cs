using CafeAPI.Domain.Entities;
using CafeAPI.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeAPI.Persistence.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {

            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id)
                .IsUnique();

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)")
                .HasDefaultValue(ReservationStatus.Beklemede); // Varsayılan durum

            builder.Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            builder.Property(e => e.CustomerEmail)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            builder.Property(e => e.CustomerPhoneNumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.ReservationDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.NumberOfPeople)
                .IsRequired()
                .HasColumnType("tinyint");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()"); // Oluşturulma tarihi

            builder.HasOne(e => e.Table)
                .WithMany()
                .HasForeignKey(e => e.TableId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CafeInfo)
                .WithMany()
                .HasForeignKey(e => e.CafeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    
    }
}
