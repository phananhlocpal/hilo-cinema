using System.ComponentModel.DataAnnotations;

namespace MovieService.Dtos.CategortDTO
{
    public class CategoryCreateDTO
    {
        [Required, MaxLength(30)]
        public string Name { get; set; }
    }
}
