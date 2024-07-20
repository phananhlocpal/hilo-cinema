using MovieService.Models;

namespace MovieService.Data.MovieTypeData
{
    public class MovieTypeRepository : IMovieTypeRepository
    {
        private readonly MovieDbContext _context;
        public MovieTypeRepository(MovieDbContext context)
        {
            _context = context;
        }


        public IEnumerable<MovieType> GetAll()
        {
            IEnumerable<MovieType> types = _context.Movie_Type.ToList();
            return types;
        }

        public MovieType GetById(int id)
        {
            MovieType type = _context.Movie_Type.FirstOrDefault(x => x.Id == id);
            return type;
        }

        public void Insert(MovieType type)
        {
            _context.Movie_Type.Add(type);

        }

        public void Update(int id, MovieType type)
        {
            MovieType currentType = _context.Movie_Type.FirstOrDefault(x => x.Id == id);
            if (currentType != null)
            {
                currentType.Name = type.Name;

                _context.SaveChanges();
            }
        }
        public bool saveChange()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
