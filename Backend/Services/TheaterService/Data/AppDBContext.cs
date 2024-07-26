using Microsoft.EntityFrameworkCore;
using TheaterService.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TheaterService.Data
{
    public partial class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public virtual DbSet<TheaterModel> Theaters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Theater;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TheaterModel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Theaters__3213E83FBBBD0B12");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .HasColumnName("city");
                entity.Property(e => e.DetailAddress)
                    .HasMaxLength(100)
                    .HasColumnName("detail_address");
                entity.Property(e => e.Hotline)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("hotline");
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
