using AutoMapper;
using MovieService.Dtos.ProducerDTO;
using MovieService.Models;

namespace MovieService.Profiles
{
    public class ProducerProfile : Profile
    {
        public ProducerProfile(){
            CreateMap<Producers, ProducerReadDTO>();
            CreateMap<ProducerCreateDTO, Producers>();

        }
    }
}
