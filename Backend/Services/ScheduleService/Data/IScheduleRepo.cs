using ScheduleService.Models;

namespace ScheduleService.Data
{
    public interface IScheduleRepo
    {
        IEnumerable<Schedule> getAllSchedule();
        Schedule getScheduleByCriteria(int? theaterId=null, int? movieId=null, DateOnly? date=null, TimeOnly? time=null, string? movieType=null, int? roomId=null);
        void createSchedule(Schedule schedule);
        bool saveChange();
    }
}
