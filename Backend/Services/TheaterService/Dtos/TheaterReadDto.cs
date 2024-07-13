using System.ComponentModel.DataAnnotations;

namespace TheaterService.Dtos
{
    public class TheaterReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string DetailAddress { get; set; }
        public string Hotline { get; set; }
    }
}
