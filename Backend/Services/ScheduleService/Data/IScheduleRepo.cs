using ScheduleService.Models;

namespace ScheduleService.Data
{
    public interface IScheduleRepo
    {
        IEnumerable<ScheduleModel> getAllSchedule();
        ScheduleModel getScheduleByCriteria(int? theaterId=null, int? movieId=null, DateOnly? date=null, TimeSpan? time=null, string? movieType=null, int? roomId=null);
        void createSchedule(ScheduleModel schedule);
        bool saveChange();
    }
}
