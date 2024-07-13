using TheaterService.Models;

namespace TheaterService.Data
{
    public class TheaterRepo : ITheaterRepo
    {
        private readonly AppDBContext _context;

        public TheaterRepo(AppDBContext context) 
        {
            _context = context;
        }

        public void createTheater(TheaterModel theater)
        {
            if (theater == null)
            {
                throw new ArgumentNullException(nameof(theater));
            }
            _context.Theaters.Add(theater);
        }

        public IEnumerable<TheaterModel> getAllTheaters()
        {
            return _context.Theaters.ToList();
        }

        public TheaterModel getTheaterById(int id)
        {
            return _context.Theaters.FirstOrDefault(theater => theater.Id == id);
        }

        public bool saveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
