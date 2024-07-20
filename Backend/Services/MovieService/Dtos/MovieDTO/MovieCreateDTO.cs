using System.ComponentModel.DataAnnotations;

namespace MovieService.Dtos.MovieDTO
{
    public class MovieCreateDTO
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime Released_Date { get; set; }
        public double Rate { get; set; }
        [MaxLength(20)]
        public string Country { get; set; }
        [MaxLength(30)]
        public string Director { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public byte[] Img_Small { get; set; }
        public byte[] Img_Large { get; set; }
        [MaxLength(100)]
        public string Trailer { get; set; }
    }
}
