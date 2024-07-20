using System.ComponentModel.DataAnnotations;

namespace MovieService.Models
{
    public class Categories
    {
        [Key, Required]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
    }
}
