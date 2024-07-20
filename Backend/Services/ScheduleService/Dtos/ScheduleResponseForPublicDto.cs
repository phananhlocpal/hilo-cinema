namespace ScheduleService.Dtos
{
    public class ScheduleResponseForPublicDto
    {
        public string Day { get; set; }
        public List<DetailScheduleDto> DetailSchedule { get; set; }
    }

    public class DetailScheduleDto
    {
        public string Theater { get; set; }
        public List<ScheduleDetailDto> Schedules { get; set; }
    }

    public class ScheduleDetailDto
    {
        public string Type { get; set; }
        public List<string> Times { get; set; }
    }
}
