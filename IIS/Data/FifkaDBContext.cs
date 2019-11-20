using IIS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using IIS.Services;
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
        public DbSet<Participant> Participants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Fifka"));
        }
        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Statistics>()
                .HasOne(t => t.Tournament)
                .WithMany(t => t.Statistics)
                .OnDelete(DeleteBehavior.Cascade);
            bldr.Entity<Match>()
                .HasOne(t => t.Tournament)
                .WithMany(t => t.Matches)
                .OnDelete(DeleteBehavior.Cascade);
            bldr.Entity<UsersInMatch>()
                .HasOne(t => t.Match)
                .WithMany(t => t.UsersInMatches)
                .OnDelete(DeleteBehavior.Cascade);
            bldr.Entity<TeamsInMatch>()
                .HasOne(t => t.Match)
                .WithMany(t => t.TeamsInMatches)
                .OnDelete(DeleteBehavior.Cascade);

            var password1 = new PasswordHasher("purkyne");
            var password2 = new PasswordHasher("netflix");
            var password3 = new PasswordHasher("heslicko");
            var password4 = new PasswordHasher("conan");
            bldr.Entity<User>()
                .HasData(new
                {
                    UserId = 1,
                    FirstName = "Daniel",
                    LastName = "Weis",
                    Email = "weisko123@azet.sk",
                    Password = password1.GetHashedPassword(),
                    TeamId = 1,
                    isAdmin = false
                },
                new
                {
                    UserId = 2,
                    FirstName = "Walter",
                    LastName = "White",
                    Email = "breaking@bad.bb",
                    Password = password2.GetHashedPassword(),
                    TeamId = 1,
                    isAdmin = false
                },
                new
                {
                    UserId = 3,
                    FirstName = "Adam",
                    LastName = "Pered",
                    Email = "vsetkodobre@gmail.com",
                    Password = password3.GetHashedPassword(),
                    TeamId = 2,
                    isAdmin = true
                },
                new
                {
                    UserId = 4,
                    FirstName = "Jordan",
                    LastName = "Schlansky",
                    Email = "js@coco.tv",
                    Password = password4.GetHashedPassword(),
                    TeamId = 2,
                    isAdmin = false
                }); ;

            bldr.Entity<Team>()
                .HasData(new
                {
                    TeamId = 1,
                    Name = "Sicaci",
                    Logo = 1
                },
                new
                {
                    TeamId = 2,
                    Name = "CastroTeam",
                    Logo = 2
                });

            bldr.Entity<Tournament>()
                .HasData(new
                {
                    TournamentId = 1,
                    Name = "FIT - BIT",
                    Location = "Bozetechova",
                    Prize = 500,
                    Entry = 5,
                    Capacity = 16,
                    Type = "Duo",
                    Organizer = "Daniel Weis",
                    Date = "2019-10-31",
                    Time = "14:00",
                    Sponsors = "Coca Cola",
                    Referee = "Adam Pered"
                },
                new
                {
                    TournamentId = 2,
                    Name = "FIT - MIT",
                    Location = "Bozetechova",
                    Prize = 1000,
                    Entry = 100,
                    Capacity = 8,
                    Type = "Solo",
                    Organizer = "Alfonz Hrozny",
                    Date = "2019-10-30",
                    Time = "14:00",
                    Sponsors = "Pepsi, Hyundai",
                    Referee = "Daniel Weis"
                });

            bldr.Entity<Participant>()
                .HasData(new
                {
                    ParticipantId = 1,
                    Name = "Daniel Weis",
                    UserOrTeam = 1,
                    IsUser = true,
                    TournamentId = 2
                },
                new
                {
                    ParticipantId = 2,
                    Name = "Walter White",
                    UserOrTeam = 2,
                    IsUser = true,
                    TournamentId = 2
                },
                new
                {
                    ParticipantId = 3,
                    Name = "Sicaci",
                    UserOrTeam = 1,
                    IsUser = false,
                    TournamentId = 1
                },
                new
                {
                    ParticipantId = 4,
                    Name = "CastroTeam",
                    UserOrTeam = 2,
                    IsUser = false,
                    TournamentId = 1
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
                    UserId = 1
                },
                new
                {
                    StatisticsId = 2,
                    Goals = 0,
                    Games = 5,
                    Wins = 0,
                    Draws = 3,
                    Loses = 2,
                    UserId = 2
                },
                new
                {
                    StatisticsId = 3,
                    Goals = 4,
                    Games = 5,
                    Wins = 0,
                    Draws = 3,
                    Loses = 2,
                    UserId = 3
                },
                new
                {
                    StatisticsId = 4,
                    Goals = 0,
                    Games = 0,
                    Wins = 0,
                    Draws = 0,
                    Loses = 0,
                    UserId = 4
                },
                new
                {
                    StatisticsId = 5,
                    Goals = 9,
                    Games = 1,
                    Wins = 1,
                    Draws = 0,
                    Loses = 0,
                    Team = "Sicaci"
                },
                new
                {
                    StatisticsId = 6,
                    Goals = 1,
                    Games = 2,
                    Wins = 1,
                    Draws = 0,
                    Loses = 1,
                    Team = "CastroTeam"
                },
                new
                {
                    StatisticsId = 7,
                    Goals = 1,
                    Games = 1,
                    Wins = 0,
                    Draws = 1,
                    Loses = 0,
                    UserId = 1,
                    TournamentId = 2
                },
                new
                {
                    StatisticsId = 8,
                    Goals = 1,
                    Games = 1,
                    Wins = 0,
                    Draws = 1,
                    Loses = 0,
                    UserId = 2,
                    TournamentId = 2
                },
                new
                {
                    StatisticsId = 9,
                    Goals = 9,
                    Games = 1,
                    Wins = 1,
                    Draws = 0,
                    Loses = 0,
                    Team = "Sicaci",
                    TournamentId = 1
                },
                new
                {
                    StatisticsId = 10,
                    Goals = 0,
                    Games = 1,
                    Wins = 0,
                    Draws = 0,
                    Loses = 1,
                    Team = "CastroTeam",
                    TournamentId = 1
                });

            bldr.Entity<Match>()
                .HasData(new 
                {
                    MatchId = 1,
                    HomeScore = 1,
                    AwayScore = 2,
                    HomeUserId = 1,
                    AwayUserId = 2,
                    Winner = "Away",
                    TournamentId = 2,
                    Round = 1
                },
                new
                {
                    MatchId = 2,
                    HomeScore = 9,
                    AwayScore = 0,
                    Winner = "Home",
                    HomeTeam = "Sicaci",
                    AwayTeam = "CastroTeam",
                    TournamentId = 1,
                    Round = 1
                });

            bldr.Entity<UsersInMatch>()
                .HasData(new
                {
                    UsersInMatchId = 1,
                    Home = true,
                    UserId = 1,
                    MatchId = 1
                },
                new
                {
                    UsersInMatchId = 2,
                    Home = false,
                    UserId = 2,
                    MatchId = 1
                });

            bldr.Entity<TeamsInMatch>()
                .HasData(new
                { 
                    TeamsInMatchId = 1,
                    Home = true,
                    TeamId = 1,
                    MatchId = 2
                },
                new
                {
                    TeamsInMatchId = 2,
                    Home = false,
                    TeamId = 2,
                    MatchId = 2
                });
        }
    }
}
