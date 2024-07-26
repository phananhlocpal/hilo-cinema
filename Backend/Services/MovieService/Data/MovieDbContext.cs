using Microsoft.EntityFrameworkCore;
using MovieService.Models;

namespace MovieService.Data
{
    public partial class MovieDbContext : DbContext
    {
        public MovieDbContext()
        {
        }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }

        public virtual DbSet<Category> Category { get; set; }

        public virtual DbSet<Movie> Movie { get; set; }

        public virtual DbSet<MovieType> MovieType { get; set; }

        public virtual DbSet<Producers> Producer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=DESKTOP-BM7NF3L;Initial Catalog=Movie;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Actor__3213E83F4281B9F3");

                entity.ToTable("Actor");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");
                entity.Property(e => e.Img)
                    .HasColumnType("image")
                    .HasColumnName("img");
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Category__3213E83FDDA546EE");

                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Movie__3213E83F1404FB18");

                entity.ToTable("Movie");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .HasColumnName("country");
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");
                entity.Property(e => e.Director)
                    .HasMaxLength(30)
                    .HasColumnName("director");
                entity.Property(e => e.Duration).HasColumnName("duration");
                entity.Property(e => e.ImgLarge)
                    .HasColumnType("image")
                    .HasColumnName("img_large");
                entity.Property(e => e.ImgSmall)
                    .HasColumnType("image")
                    .HasColumnName("img_small");
                entity.Property(e => e.Rate).HasColumnName("rate");
                entity.Property(e => e.ReleasedDate).HasColumnName("released_date");
                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");
                entity.Property(e => e.Trailer)
                    .HasMaxLength(100)
                    .HasColumnName("trailer");

                entity.HasMany(d => d.Actors).WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieActor",
                        r => r.HasOne<Producers>().WithMany()
                            .HasForeignKey("ActorId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__Movie_Act__actor__534D60F1"),
                        l => l.HasOne<Movie>().WithMany()
                            .HasForeignKey("MovieId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__Movie_Act__movie__52593CB8"),
                        j =>
                        {
                            j.HasKey("MovieId", "ActorId").HasName("PK__Movie_Ac__DB7FB332FAF9F92A");
                            j.ToTable("Movie_Actor");
                            j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                            j.IndexerProperty<int>("ActorId").HasColumnName("actor_id");
                        });

                entity.HasMany(d => d.Categories).WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieCategory",
                        r => r.HasOne<Category>().WithMany()
                            .HasForeignKey("CategoryId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__Movie_Cat__categ__47DBAE45"),
                        l => l.HasOne<Movie>().WithMany()
                            .HasForeignKey("MovieId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__Movie_Cat__movie__46E78A0C"),
                        j =>
                        {
                            j.HasKey("MovieId", "CategoryId").HasName("PK__Movie_Ca__DE9919D279EA655F");
                            j.ToTable("Movie_Categories");
                            j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                            j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                        });

                entity.HasMany(d => d.MovieTypes).WithMany(p => p.MoviesNavigation)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieMovieType",
                        r => r.HasOne<Producers>().WithMany()
                            .HasForeignKey("MovieTypeId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__Movie_Mov__movie__59063A47"),
                        l => l.HasOne<Movie>().WithMany()
                            .HasForeignKey("MovieId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__Movie_Mov__movie__5812160E"),
                        j =>
                        {
                            j.HasKey("MovieId", "MovieTypeId").HasName("PK__Movie_Mo__A44704E578E1079B");
                            j.ToTable("Movie_MovieType");
                            j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                            j.IndexerProperty<int>("MovieTypeId").HasColumnName("movieType_id");
                        });

                entity.HasMany(d => d.Producers).WithMany(p => p.Movies1)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieProducer",
                        r => r.HasOne<Producers>().WithMany()
                            .HasForeignKey("ProducerId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__Movie_Pro__produ__4D94879B"),
                        l => l.HasOne<Movie>().WithMany()
                            .HasForeignKey("MovieId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__Movie_Pro__movie__4CA06362"),
                        j =>
                        {
                            j.HasKey("MovieId", "ProducerId").HasName("PK__Movie_Pr__1D6A04452D4C56FB");
                            j.ToTable("Movie_Producer");
                            j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                            j.IndexerProperty<int>("ProducerId").HasColumnName("producer_id");
                        });
            });

            modelBuilder.Entity<MovieType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__MovieTyp__3213E83F902F7A07");

                entity.ToTable("MovieType");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Producers>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Producer__3213E83FC4E47F84");

                entity.ToTable("Producer");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description");
                entity.Property(e => e.Img)
                    .HasColumnType("image")
                    .HasColumnName("img");
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
