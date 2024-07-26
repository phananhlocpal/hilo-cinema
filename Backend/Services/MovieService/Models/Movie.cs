using MovieService.Data;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MovieService.Models
{
    public class Movie
    {
        [Key, Required]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime ReleasedDate { get; set; }
        public double Rate { get; set; }
        [MaxLength(20)]
        public string Country { get; set; }
        [MaxLength(30)]
        public string Director { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public byte[]? ImgSmall { get; set; }
        public byte[]? ImgLarge { get; set; }
        [MaxLength(100)]
        public string? Trailer { get; set; }
        public virtual ICollection<Producers> Actors { get; set; } = new List<Producers>();

        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

        public virtual ICollection<Producers> MovieTypes { get; set; } = new List<Producers>();

        public virtual ICollection<Producers> Producers { get; set; } = new List<Producers>();
    }
}
