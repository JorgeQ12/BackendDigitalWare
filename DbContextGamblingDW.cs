using GamblingBackDW.Domain.Entities;
using GamblingBackDW.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GamblingBackDW
{
    public class DbContextGamblingDW : DbContext
    {
        public DbSet<Gamblings> Gamblings { get; set; }
        public DbSet<Matches> Matches { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<SessionPerson> SessionPerson {  get; set; }
        public DbSet<Teams> Teams { get; set; }

        public DbContextGamblingDW(DbContextOptions<DbContextGamblingDW> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configuración de la relación Matches.TeamA con Teams
            modelBuilder.Entity<Matches>()
                .HasOne(m => m.TeamA)
                .WithMany()
                .HasForeignKey(m => m.IdTeamA)
                .OnDelete(DeleteBehavior.Restrict); 

            // Configuración de la relación Matches.TeamB con Teams
            modelBuilder.Entity<Matches>()
                .HasOne(m => m.TeamB)
                .WithMany()
                .HasForeignKey(m => m.IdTeamB)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación Matches.TeamB con Teams
            modelBuilder.Entity<Gamblings>()
                .HasOne(m => m.Session)
                .WithMany()
                .HasForeignKey(m => m.IdSession)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación Matches.TeamB con Teams
            modelBuilder.Entity<Gamblings>()
                .HasOne(m => m.SessionPerson)
                .WithMany()
                .HasForeignKey(m => m.IdSessionPerson)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
