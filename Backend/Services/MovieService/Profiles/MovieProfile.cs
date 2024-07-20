using AutoMapper;
using MovieService.Dtos.MovieDTO;
using MovieService.Models;

namespace MovieService.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile() {
            CreateMap<Movies, MovieReadDTO>();
            CreateMap<MovieCreateDTO, Movies>();
        }
    }
}
