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
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<UsersInMatch>  UsersInMatches { get; set; }
        public DbSet<TeamsInMatch> TeamsInMatches { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Fifka"));
        }
        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Tournament>().Property(p => p.Participants).HasConversion(v => string.Join(',', v), v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

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
                    TeamId = 1,
                    Name = "Sicaci",
                });
            bldr.Entity<Match>()
                .HasData(new
                {
                    MatchId = 1,
                    HomeTeam = "Hurbanovo",
                    AwayTeam = "Imel",
                    HomeScore = 1,
                    AwayScore = 0
                });
            bldr.Entity<Tournament>()
                .HasData(new
                {
                    TournamentId = 1,
                    Name = "FIT - BIT",
                    Location = "Bozetechova",
                    Prize = 500,
                    Entry = 600,
                    Capacity = 800,
                    Type = "duo",
                    OrganizerUserId = 1
                },
                new
                {
                    TournamentId = 2,
                    Name = "FIT - BIT2",
                    Location = "Bozetechova2",
                    Prize = 5002,
                    Entry = 6002,
                    Capacity = 802,
                    Type = "duo",
                },
                new
                {
                    TournamentId = 3,
                    Name = "FIT - BIT3",
                    Location = "Bozetechova3",
                    Prize = 5003,
                    Entry = 6003,
                    Capacity = 803,
                    Type = "solo",
                },
                new
                {
                    TournamentId = 4,
                    Name = "FIT - BIT4",
                    Location = "Bozetechova4",
                    Prize = 504,
                    Entry = 604,
                    Capacity = 804,
                    Type = "duo",
                },
                new
                {
                    TournamentId = 5,
                    Name = "FIT - BIT5",
                    Location = "Bozetechova5",
                    Prize = 505,
                    Entry = 605,
                    Capacity = 805,
                    Type = "solo",
                });
            bldr.Entity<Statistics>()
                .HasData(new
                {
                    StatisticsId = 1,
                    Goals = 5,
                    Games = 2,
                    Wins = 1,
                    Draws = 1,
                    Loses = 0,
                },
                new
                {
                    StatisticsId = 2,
                    Goals = 0,
                    Games = 5,
                    Wins = 0,
                    Draws = 3,
                    Loses = 2,
                    TeamId = 1,
                    UserId = 1
                }); 
            bldr.Entity<UsersInMatch>()
                .HasData(new
                {
                    UsersInMatchId = 1,
                    UserId = 1,
                    MatchId = 1,
                    Home = true
                });
        }
    }
}
