using System.ComponentModel.DataAnnotations;

namespace MovieService.Models
{
    public class Actor
    {
        [Key, Required]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public byte[]? Img { get; set; }
    }
}
