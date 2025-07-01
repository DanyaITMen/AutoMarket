using System.ComponentModel.DataAnnotations;

namespace AutoMarket.DAL.Entities
{
    public class Car
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Brand { get; set; }
        [Required, MaxLength(50)]
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int Mileage { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required, MaxLength(50)]
        public string Region { get; set; }
        [MaxLength(200)]
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
    }
}