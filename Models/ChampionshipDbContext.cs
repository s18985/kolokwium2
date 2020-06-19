using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Models
{
    public class ChampionshipDbContext : DbContext
    {
        public DbSet<Championship> Championship { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<ChampionshipTeam> ChampionshipTeam { get; set; }
        public DbSet<PlayerTeam> PlayerTeam { get; set; }

        public ChampionshipDbContext()
        {

        }

        public ChampionshipDbContext(DbContextOptions<ChampionshipDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Championship>(entity =>
            {
                entity.HasKey(e => e.IdChampionship);

                entity.Property(e => e.IdChampionship).ValueGeneratedNever();
                entity.Property(e => e.OfficialName).HasMaxLength(100).IsRequired();

            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.IdTeam);

                entity.Property(e => e.IdTeam).ValueGeneratedNever();
                entity.Property(e => e.TeamName).HasMaxLength(30).IsRequired();

            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.IdPlayer);

                entity.Property(e => e.IdPlayer).ValueGeneratedNever();
                entity.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(50).IsRequired();

            });

            modelBuilder.Entity<ChampionshipTeam>(entity =>
            {
                entity.HasKey(e => new { e.IdTeam, e.IdChampionship });
                entity.ToTable("Championship_Team");

                entity.HasOne(e => e.Team)
                .WithMany(e => e.ChampionshipTeams)
                .HasForeignKey(e => e.IdTeam);

                entity.HasOne(e => e.Championship)
                .WithMany(e => e.ChampionshipTeams)
                .HasForeignKey(e => e.IdChampionship);

            });

            modelBuilder.Entity<PlayerTeam>(entity =>
            {
                entity.HasKey(e => new { e.IdPlayer, e.IdTeam });
                entity.ToTable("Player_Team");

                entity.HasOne(e => e.Team)
                .WithMany(e => e.PlayerTeams)
                .HasForeignKey(e => e.IdTeam);

                entity.HasOne(e => e.Player)
                .WithMany(e => e.PlayerTeams)
                .HasForeignKey(e => e.IdPlayer);

                entity.Property(e => e.Comment).HasMaxLength(300);
            });
        }
    }
}
