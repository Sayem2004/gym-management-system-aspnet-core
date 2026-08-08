using System;
using System.Collections.Generic;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public partial class GymManagementDbContext : DbContext
{
    public GymManagementDbContext()
    {
    }

    public GymManagementDbContext(DbContextOptions<GymManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DbConn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.PackageId).HasName("PK__Package__322035CCE6EE57D2");

            entity.ToTable("Package");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Trainer).WithMany(p => p.Packages)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK__Package__Trainer__403A8C7D");

            entity.HasOne(d => d.User).WithMany(p => p.Packages)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Package__UserId__412EB0B6");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B4904ADEF19");

            entity.ToTable("Schedule");

            entity.Property(e => e.DayName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SessionName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Trainer).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_Trainer");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.ToTable("Trainer");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Speciality)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
