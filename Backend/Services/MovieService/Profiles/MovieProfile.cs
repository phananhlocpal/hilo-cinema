using AutoMapper;
using MovieService.Dtos.MovieDTO;
using MovieService.Models;

namespace MovieService.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile() {
            CreateMap<Movie, MovieReadDTO>();
            CreateMap<MovieCreateDTO, Movie>();
        }
    }
}
