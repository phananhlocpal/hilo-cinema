using System.ComponentModel.DataAnnotations;

namespace MovieService.Models
{
    public class Producers
    {
        [Key, Required]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public byte[]? Img { get; set; }
        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

        public virtual ICollection<Movie> Movies1 { get; set; } = new List<Movie>();

        public virtual ICollection<Movie> MoviesNavigation { get; set; } = new List<Movie>();
    }
}
