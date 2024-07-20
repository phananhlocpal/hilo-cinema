using MovieService.Models;

namespace MovieService.Data.MovieTypeData
{
    public interface IMovieTypeRepository
    {
        IEnumerable<MovieType> GetAll();
        MovieType GetById(int id);
        void Insert(MovieType type);
        void Update(int id, MovieType type);
        bool saveChange();
    }
}
