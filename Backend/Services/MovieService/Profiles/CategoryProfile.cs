using AutoMapper;
using MovieService.Dtos.CategortDTO;
using MovieService.Models;

namespace MovieService.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() {
            CreateMap<Category, CategoryReadDTO>();
            CreateMap<CategoryCreateDTO, Category>();
        }
    }
}
