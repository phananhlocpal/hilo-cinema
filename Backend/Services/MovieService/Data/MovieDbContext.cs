using Microsoft.EntityFrameworkCore;
using MovieService.Models;

namespace MovieService.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext()
        {
        }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Movies> Movie { get; set; }
        public virtual DbSet<Producers> Producer { get; set; }
        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<MovieType> Movie_Type { get; set; }
    }
}
