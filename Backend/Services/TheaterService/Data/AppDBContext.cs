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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=DESKTOP-BM7NF3L; Database=Theater;Integrated Security=True; TrustServerCertificate=True;");

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
