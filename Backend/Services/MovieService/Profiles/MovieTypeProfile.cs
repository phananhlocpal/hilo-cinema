using AutoMapper;
using MovieService.Dtos.MovieTypeDTO;
using MovieService.Models;

namespace MovieService.Profiles
{
    public class MovieTypeProfile : Profile
    {
        public MovieTypeProfile()
        {
            CreateMap<MovieType, MovieTypeReadDTO>();
            CreateMap<MovieTypeCreateDTO, MovieType>();
        }
    }
}
