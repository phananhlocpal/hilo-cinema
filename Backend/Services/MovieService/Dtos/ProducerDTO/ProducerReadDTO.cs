using System.ComponentModel.DataAnnotations;

namespace MovieService.Dtos.ProducerDTO
{
    public class ProducerReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Img { get; set; }
    }
}
