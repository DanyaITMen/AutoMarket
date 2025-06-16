using AutoMarket.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.Web.Data
{
    public class AutoMarketDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        public AutoMarketDbContext(DbContextOptions<AutoMarketDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Brand).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Model).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Region).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.ImageUrl).HasMaxLength(200);
                entity.HasOne(e => e.Category)
                      .WithMany(c => c.Cars)
                      .HasForeignKey(e => e.CategoryId);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Cars)
                      .HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
                entity.HasData(
                    new Category { Id = 1, Name = "Седан" },
                    new Category { Id = 2, Name = "Внедорожник" },
                    new Category { Id = 3, Name = "Хэтчбек" }
                );
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.PasswordHash).HasMaxLength(256).IsRequired();
                entity.Property(e => e.Role).HasMaxLength(20).IsRequired();
            });
        }
    }
}