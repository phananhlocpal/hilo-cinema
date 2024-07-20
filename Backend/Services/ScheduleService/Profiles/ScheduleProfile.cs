using AutoMapper;
using ScheduleService.Dtos;
using ScheduleService.Models;

namespace ScheduleService.Profiles
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            // Source -> Target
            
            CreateMap<ScheduleModel, ScheduleReadDto>();
            CreateMap<ScheduleCreateDto, ScheduleModel>();

        }
    }
}
