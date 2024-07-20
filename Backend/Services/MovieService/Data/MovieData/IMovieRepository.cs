using MovieService.Models;

namespace MovieService.Data.MovieData
{
    public interface IMovieRepository
    {
        IEnumerable<Movies> GetAll();
        Movies GetById(int id);
        void InsertMovie(Movies movie);
        void Update(int id, Movies movie);
        bool saveChange();
    }
}
