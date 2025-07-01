using AutoMarket.BLL.DTOs.Category;
using AutoMarket.BLL.DTOs.User;

namespace AutoMarket.BLL.DTOs.Car
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public string Region { get; set; }
        public string ImageUrl { get; set; }


        public CategoryDto Category { get; set; }
        public UserDto User { get; set; }
    }
}