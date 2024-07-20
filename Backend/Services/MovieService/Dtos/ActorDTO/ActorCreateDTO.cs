using System.ComponentModel.DataAnnotations;

namespace MovieService.Dtos.ActorDTO
{
    public class ActorCreateDTO
    {
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public byte[] Img { get; set; }
    }
}
