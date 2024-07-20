using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ScheduleService.Models;

namespace ScheduleService.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public virtual DbSet<ScheduleModel> Schedules { get; set; }

    }
}
