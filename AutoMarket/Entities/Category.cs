using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Web.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}