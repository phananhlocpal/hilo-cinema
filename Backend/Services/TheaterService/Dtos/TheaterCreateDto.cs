using System.ComponentModel.DataAnnotations;

namespace TheaterService.Dtos
{
    public class TheaterCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        public string DetailAddress { get; set; }
        public string Hotline { get; set; }
    }
}
