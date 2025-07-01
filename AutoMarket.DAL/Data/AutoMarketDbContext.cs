using AutoMarket.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AutoMarket.DAL.Data
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
            // Цей рядок автоматично знаходить і застосовує всі конфігурації
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}