using AutoMarket.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoMarket.Web.Data.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(e => e.Brand).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Model).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Region).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.ImageUrl).HasMaxLength(200);

            builder.HasOne(e => e.Category)
                  .WithMany(c => c.Cars)
                  .HasForeignKey(e => e.CategoryId);

            builder.HasOne(e => e.User)
                  .WithMany(u => u.Cars)
                  .HasForeignKey(e => e.UserId);
        }
    }
}