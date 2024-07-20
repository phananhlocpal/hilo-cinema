using AutoMapper;
using MovieService.Dtos.ActorDTO;
using MovieService.Models;

namespace MovieService.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile() {
            CreateMap<Actor, ActorReadDTO>();
            CreateMap<ActorCreateDTO, Actor>();
        }
    }
}
