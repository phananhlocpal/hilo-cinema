using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ScheduleService.Models;

namespace ScheduleService.Data;

public partial class ScheduleContext : DbContext
{
    public ScheduleContext()
    {
    }

    public ScheduleContext(DbContextOptions<ScheduleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Schedule> Schedules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-BM7NF3L;Initial Catalog=Schedule;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => new { e.TheaterId, e.MovieId, e.Date, e.Time, e.MovieType, e.RoomId }).HasName("PK__Schedule__684720379C85C324");

            entity.ToTable("Schedule");

            entity.Property(e => e.TheaterId).HasColumnName("theater_id");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.MovieType)
                .HasMaxLength(30)
                .HasColumnName("movie_type");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
