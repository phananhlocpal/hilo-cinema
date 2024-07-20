using System.ComponentModel.DataAnnotations;

namespace MovieService.Dtos.MovieTypeDTO
{
    public class MovieTypeCreateDTO
    {
        [Required, MaxLength(30)]
        public string Name { get; set; }
    }
}
