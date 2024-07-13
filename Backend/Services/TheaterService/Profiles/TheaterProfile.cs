using AutoMapper;
using TheaterService.Dtos;
using TheaterService.Models;

namespace TheaterService.Profiles
{
    public class TheaterProfile : Profile
    {
        public TheaterProfile()
        {
            // Source -> Target
            CreateMap<TheaterModel, TheaterReadDto>();
            CreateMap<TheaterCreateDto, TheaterModel>();

        }
    }
}
