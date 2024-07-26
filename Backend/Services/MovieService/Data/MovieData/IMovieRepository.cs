using MovieService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieService.Data.MovieData
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task InsertMovieAsync(Movie movie);
        Task UpdateAsync(int id, Movie movie);
        Task<bool> SaveChangesAsync();
    }
}
