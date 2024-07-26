namespace ScheduleService.Dtos
{
    public class MovieReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime Released_Date { get; set; }
        public double Rate { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public byte[] Img_Small { get; set; }
        public byte[] Img_Large { get; set; }
        public string Trailer { get; set; }
    }
}
