using AutoMarket.DAL.Data;
using AutoMarket.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.DAL.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AutoMarketDbContext context)
        {
            // Додаємо категорії, тільки якщо їх ще немає в базі
            if (!await context.Categories.AnyAsync())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Седан" },
                    new Category { Name = "Внедорожник" },
                    new Category { Name = "Хэтчбек" },
                    new Category { Name = "Купе" }
                };
                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync(); // Зберігаємо, щоб отримати Id для наступного кроку
            }

            // Додаємо користувачів, тільки якщо їх ще немає в базі
            if (!await context.Users.AnyAsync())
            {
                var users = new List<User>
                {
                    new User
                    {
                        Id = "user123",
                        Email = "test@example.com",
                        PasswordHash = "super_secret_password_hash", // В реальному проекті пароль хешується
                        Role = "Admin"
                    }
                };
                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }

            // Додаємо машини, тільки якщо їх ще немає в базі
            if (!await context.Cars.AnyAsync())
            {
                var cars = new List<Car>
                {
                    new Car
                    {
                        Brand = "BMW",
                        Model = "M5",
                        Year = 2021,
                        Price = 75000,
                        Mileage = 15000,
                        Description = "Спортивний седан у відмінному стані.",
                        CategoryId = 1, // Седан
                        Region = "Київ",
                        ImageUrl = "https://example.com/bmw_m5.jpg",
                        UserId = "user123"
                    },
                    new Car
                    {
                        Brand = "Toyota",
                        Model = "RAV4",
                        Year = 2020,
                        Price = 32000,
                        Mileage = 40000,
                        Description = "Надійний сімейний позашляховик.",
                        CategoryId = 2, // Внедорожник
                        Region = "Львів",
                        ImageUrl = "https://example.com/toyota_rav4.jpg",
                        UserId = "user123"
                    }
                };
                await context.Cars.AddRangeAsync(cars);
                await context.SaveChangesAsync();
            }
        }
    }
}