namespace ScheduleService.Models
{
    public class ScheduleModel
    {
        public int TheaterId { get; set; }
        public int MovieId { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan Time { get; set; }
        public string MovieType { get; set; }
        public int RoomId { get; set; }
    }
}
