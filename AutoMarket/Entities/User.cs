using System.ComponentModel.DataAnnotations;

namespace AutoMarket.Web.Entities
{
    public class User
    {
        [Key, MaxLength(128)]
        public string Id { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(256)]
        public string PasswordHash { get; set; }
        [Required, MaxLength(20)]
        public string Role { get; set; }
        public List<Car> Cars { get; set; }
    }
}