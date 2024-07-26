using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.Data;
using ScheduleService.Dtos;
using ScheduleService.Models;
using ScheduleService.Service;
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
        private readonly ScheduleSubcriber _schduleSubcriber;
        public ScheduleController(IScheduleRepo repository, IMapper mapper, ScheduleSubcriber schduleSubcriber)
        {
            _repository = repository;
            _mapper = mapper;
            _schduleSubcriber = schduleSubcriber;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleResponseForPublicDto>>> GetSchedulesAsync()
        {
            var scheduleItems = _repository.getAllSchedule();

            if (scheduleItems == null || !scheduleItems.Any())
            {
                return NotFound();
            }

            // Tạo dictionary để lưu trữ các lịch chiếu theo ngày
            var schedulesByDay = new Dictionary<string, List<DetailScheduleDto>>();

            foreach (var schedule in scheduleItems)
            {
                var movie = await _schduleSubcriber.GetMovieByIdAsync(schedule.MovieId);

                // Xác định ngày lịch chiếu
                var day = schedule.Date.ToString("yyyy-MM-dd");

                // Tạo ScheduleDetailDto cho từng lịch chiếu
                var scheduleDetail = new ScheduleDetailDto
                {
                    Type = schedule.MovieType,
                    Times = new List<string> { schedule.Time.ToString("HH:mm") }
                };

                // Kiểm tra nếu ngày đã tồn tại trong dictionary
                if (!schedulesByDay.ContainsKey(day))
                {
                    schedulesByDay[day] = new List<DetailScheduleDto>();
                }

                // Tìm xem theater đã tồn tại chưa
                var detailSchedule = schedulesByDay[day].FirstOrDefault(ds => ds.Theater == movie.Title);
                if (detailSchedule == null)
                {
                    detailSchedule = new DetailScheduleDto
                    {
                        Theater = movie.Title,
                        Schedules = new List<ScheduleDetailDto>()
                    };
                    schedulesByDay[day].Add(detailSchedule);
                }

                detailSchedule.Schedules.Add(scheduleDetail);
            }

            // Chuyển đổi kết quả thành List<ScheduleResponseForPublicDto>
            var scheduleResponse = schedulesByDay
                .Select(kvp => new ScheduleResponseForPublicDto
                {
                    Day = kvp.Key,
                    DetailSchedule = kvp.Value
                })
                .ToList();

            return Ok(scheduleResponse);
        }


        [HttpGet("search", Name = "GetScheduleByCriteria")]
        public ActionResult<ScheduleReadDto> GetScheduleByCriteria(
            [FromQuery] int? theaterId = null,
            [FromQuery] int? movieId = null,
            [FromQuery] DateOnly? date = null,
            [FromQuery] TimeOnly? time = null,
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
            var scheduleModel = _mapper.Map<Schedule>(scheduleCreateDto);
            _repository.createSchedule(scheduleModel);
            _repository.saveChange();

            var scheduleReadDto = _mapper.Map<ScheduleReadDto>(scheduleModel);

            return CreatedAtRoute(nameof(GetScheduleByCriteria), scheduleReadDto);
        }
    }
}
