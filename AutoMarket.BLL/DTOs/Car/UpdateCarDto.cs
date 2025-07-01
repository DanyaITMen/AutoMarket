using System.ComponentModel.DataAnnotations;

namespace AutoMarket.BLL.DTOs.Car
{
    public class UpdateCarDto
    {
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Range(1900, 2100)]
        public int Year { get; set; }

        [Range(0, 10000000)]
        public decimal Price { get; set; }

        [Range(0, 1000000)]
        public int Mileage { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Region { get; set; }

        [MaxLength(200)]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}