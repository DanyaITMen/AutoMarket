using System.ComponentModel.DataAnnotations;

namespace AutoMarket.DTOs.Category
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Назва категорії є обов'язковою")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}