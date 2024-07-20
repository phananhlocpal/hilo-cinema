using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Data;
using ScheduleService.Dtos;
using ScheduleService.Models;
using System;
using System.Collections.Generic;

namespace ScheduleService.Controllers
{
    [Route("api/ScheduleService")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepo _repository;
        private readonly IMapper _mapper;

        public ScheduleController(IScheduleRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ScheduleReadDto>> GetSchedules()
        {
            Console.WriteLine("--> Getting Schedules ... ");
            var scheduleItems = _repository.getAllSchedule();
            return Ok(_mapper.Map<IEnumerable<ScheduleReadDto>>(scheduleItems));
        }

        [HttpGet("search", Name = "GetScheduleByCriteria")]
        public ActionResult<ScheduleReadDto> GetScheduleByCriteria(
            [FromQuery] int? theaterId = null,
            [FromQuery] int? movieId = null,
            [FromQuery] DateOnly? date = null,
            [FromQuery] TimeSpan? time = null,
            [FromQuery] string? movieType = null,
            [FromQuery] int? roomId = null)
        {
            var scheduleItem = _repository.getScheduleByCriteria(theaterId, movieId, date, time, movieType, roomId);
            if (scheduleItem != null)
            {
                return Ok(_mapper.Map<ScheduleReadDto>(scheduleItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<ScheduleReadDto> CreateSchedule(ScheduleCreateDto scheduleCreateDto)
        {
            var scheduleModel = _mapper.Map<ScheduleModel>(scheduleCreateDto);
            _repository.createSchedule(scheduleModel);
            _repository.saveChange();

            var scheduleReadDto = _mapper.Map<ScheduleReadDto>(scheduleModel);

            return CreatedAtRoute(nameof(GetScheduleByCriteria), scheduleReadDto);
        }
    }
}
