using MovieService.Data;
using System.ComponentModel.DataAnnotations;

namespace MovieService.Models
{
    public class Category
    {
        [Key, Required]
        public int Id { get; set; }
        [MaxLength(30)]
        public string? Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
