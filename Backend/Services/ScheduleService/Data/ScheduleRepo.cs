﻿using ScheduleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleService.Data
{
    public class ScheduleRepo : IScheduleRepo
    {
        private readonly AppDBContext _context;

        public ScheduleRepo(AppDBContext context)
        {
            _context = context;
        }

        public void createSchedule(ScheduleModel schedule)
        {
            if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }
            _context.Schedules.Add(schedule);
        }

        public IEnumerable<ScheduleModel> getAllSchedule()
        {
            return _context.Schedules.ToList();
        }

        public ScheduleModel getScheduleByCriteria(int? theaterId = null, int? movieId = null, DateOnly? date = null, TimeSpan? time = null, string? movieType = null, int? roomId = null)
        {
            var query = _context.Schedules.AsQueryable();

            if (theaterId.HasValue)
            {
                query = query.Where(s => s.TheaterId == theaterId.Value);
            }

            if (movieId.HasValue)
            {
                query = query.Where(s => s.MovieId == movieId.Value);
            }

            if (date.HasValue)
            {
                query = query.Where(s => s.Date == date.Value);
            }

            if (time.HasValue)
            {
                query = query.Where(s => s.Time == time.Value);
            }

            if (!string.IsNullOrEmpty(movieType))
            {
                query = query.Where(s => s.MovieType == movieType);
            }

            if (roomId.HasValue)
            {
                query = query.Where(s => s.RoomId == roomId.Value);
            }

            return query.FirstOrDefault();
        }

        public bool saveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}