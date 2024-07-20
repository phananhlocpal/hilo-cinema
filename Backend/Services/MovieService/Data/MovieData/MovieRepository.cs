using MovieService.Exception;
using MovieService.Models;

namespace MovieService.Data.MovieData
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;
        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Movies> GetAll()
        {
            IEnumerable<Movies> movies = _context.Movie.ToList();
            return movies;        }

        public Movies GetById(int id)
        {
                Movies movie = _context.Movie.FirstOrDefault(x => x.Id == id);
                return movie;
        }

        public void InsertMovie(Movies movie)
        {
            _context.Movie.Add(movie);

        }

        public void Update(int id, Movies movie)
        {
            Movies currentMovie = _context.Movie.FirstOrDefault(x => x.Id == id);
            if (currentMovie != null)
            {
                currentMovie.Title = movie.Title;
                currentMovie.Duration = movie.Duration;
                currentMovie.Released_Date = movie.Released_Date;
                currentMovie.Rate = movie.Rate;
                currentMovie.Country = movie.Country;
                currentMovie.Director = movie.Director;
                currentMovie.Description = movie.Description;
                currentMovie.Img_Small = movie.Img_Small;
                currentMovie.Img_Large = movie.Img_Large;
                currentMovie.Trailer = movie.Trailer;

                _context.SaveChanges();
            }
        }
        public bool saveChange()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
