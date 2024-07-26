using MovieService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieService.Data.MovieData
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movie.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movie.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertMovieAsync(Movie movie)
        {
            await _context.Movie.AddAsync(movie);
        }

        public async Task UpdateAsync(int id, Movie movie)
        {
            var currentMovie = await _context.Movie.FindAsync(id);
            if (currentMovie != null)
            {
                _context.Entry(currentMovie).CurrentValues.SetValues(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
