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
                    UserId = 1,
                    FirstName = "Daniel",
                    LastName = "Weis",
                    Email = "weisthejew@azet.sk",
                    Password = "pepemobil123"
                },
                new
                {
                    UserId = 2,
                    FirstName = "Walter",
                    LastName = "White",
                    Email = "breaking@bad.bb",
                    Password = "asd"
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
                    TournamentId = 1,
                    Name = "FIT - BIT",
                    Location = "Bozetechova",
                    Date = new DateTime(2019, 10, 6),
                    Prize = 500,
                    Entry = 600,
                    Capacity = 800,
                    Type = TournamentType.Duo,
                    UserId = 1,
                    Sponsors = new List<string>()
                    {
                        "Abidas",
                        "Umbro"
                    }
                },
                new
                {
                    TournamentId = 2,
                    Name = "FIT - BIT2",                    
                    Location = "Bozetechova2",
                    Date = new DateTime(2019, 10, 7),
                    Prize = 5002,
                    Entry = 6002,
                    Capacity = 802,
                    Type = TournamentType.Duo,
                    Sponsors = new List<string>()
                    {
                        "Abidas",
                        "Umbro"
                    }
                },
                new
                {
                    TournamentId = 3,
                    Name = "FIT - BIT3",
                    Location = "Bozetechova3",
                    Date = new DateTime(2019, 10, 8),
                    Prize = 5003,
                    Entry = 6003,
                    Capacity = 803,
                    Type = TournamentType.Solo,
                    Sponsors = new List<string>()
                    {
                        "Abidas",
                        "Umbro"
                    }
                },
                new
                {
                    TournamentId = 4,
                    Name = "FIT - BIT4",
                    Location = "Bozetechova4",
                    Date = new DateTime(2019, 10, 9),
                    Prize = 504,
                    Entry = 604,
                    Capacity = 804,
                    Type = TournamentType.Duo,
                    Sponsors = new List<string>()
                    {
                        "Abidas",
                        "Umbro"
                    }
                },
                new
                {
                    TournamentId = 5,
                    Name = "FIT - BIT5",
                    Location = "Bozetechova5",
                    Date = new DateTime(2019, 10, 10),
                    Prize = 505,
                    Entry = 605,
                    Capacity = 805,
                    Type = TournamentType.Solo,
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
