using AutoMapper;
using MovieService.Dtos.CategortDTO;
using MovieService.Models;

namespace MovieService.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() {
            CreateMap<Categories, CategoryReadDTO>();
            CreateMap<CategoryCreateDTO, Categories>();
        }
    }
}
