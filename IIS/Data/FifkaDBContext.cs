using IIS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace IIS.Data
{
    public class FifkaDBContext : DbContext
    {
        private readonly IConfiguration _config;
        public FifkaDBContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Fifka"));
        }
        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<User>()
                .HasData(new
                {
                    UserID = 1,
                    FirstName = "Daniel",
                    LastName = "Weis",
                    Email = "weisthejew@azet.sk",
                    Password = "pepemobil123"
                });
            bldr.Entity<Team>()
                .HasData(new
                {
                    TeamID = 1,
                    Name = "Sicaci",
                });
            bldr.Entity<Match>()
                .HasData(new
                {
                    MatchID = 1,
                    HomeTeam = "Hurbanovo",
                    AwayTeam = "Imel",
                    Date = new DateTime(2019,10,6),
                    HomeScore = 1,
                    AwayScore = 0
                });
            bldr.Entity<Tournament>()
                .HasData(new
                {
                    TournamentID = 1,
                    Name = "FIT - BIT",
                    Locatioin = "Bozetechova",
                    Date = new DateTime(2019, 10, 6),
                    Prize = 500,
                    Entry = 600,
                    Capacity = 800,
                    Type = TournamentType.Duo,
                    Sponsors = new List<string>()
                    {
                        "Abidas",
                        "Umbro"
                    }
                });
            bldr.Entity<Statistics>()
                .HasData(new
                {
                    StatisticsID = 1,
                    Goals = 5,
                    Games = 2,
                    Wins = 1,
                    Draws = 1,
                    Loses = 0
                });
        }
    }
}
