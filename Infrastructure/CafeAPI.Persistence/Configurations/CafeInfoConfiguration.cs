using CafeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeAPI.Persistence.Configurations
{
    public class CafeInfoConfiguration : IEntityTypeConfiguration<CafeInfo>
    {
        public void Configure(EntityTypeBuilder<CafeInfo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.ImageUrl)
                .HasMaxLength(300);

            builder.Property(e => e.OpeningHours)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.WebsiteUrl)
                .HasMaxLength(200);

            builder.Property(e => e.InstagramUrl)
                .HasMaxLength(200);

            builder.Property(e => e.FacebookUrl)
                .HasMaxLength(200);

            builder.Property(e => e.TwitterUrl)
                .HasMaxLength(200);

            builder.Property(e => e.YoutubeUrl)
                .HasMaxLength(200);
        }
    }
}
