using CafeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeAPI.Persistence.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.UserId)
                   .IsRequired();

            builder.Property(r => r.Comment)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(r => r.Rating)
                   .IsRequired();

            builder.Property(r => r.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime");

            // İlişkiler

            // Review - CafeInfo İlişkisi (Many-to-One)
            builder.HasOne(r => r.CafeInfo)
                   .WithMany()
                   .HasForeignKey(r => r.CafeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
