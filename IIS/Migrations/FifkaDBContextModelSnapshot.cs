﻿// <auto-generated />
using System;
using IIS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IIS.Migrations
{
    [DbContext(typeof(FifkaDBContext))]
    partial class FifkaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IIS.Data.Entities.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwayScore")
                        .HasColumnType("int");

                    b.Property<string>("AwayTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AwayUserId")
                        .HasColumnType("int");

                    b.Property<int>("HomeScore")
                        .HasColumnType("int");

                    b.Property<string>("HomeTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HomeUserId")
                        .HasColumnType("int");

                    b.Property<int>("Round")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.Property<string>("Winner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MatchId");

                    b.HasIndex("AwayUserId");

                    b.HasIndex("HomeUserId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Matches");

                    b.HasData(
                        new
                        {
                            MatchId = 1,
                            AwayScore = 2,
                            AwayUserId = 2,
                            HomeScore = 1,
                            HomeUserId = 1,
                            Round = 1,
                            TournamentId = 2,
                            Winner = "Away"
                        },
                        new
                        {
                            MatchId = 2,
                            AwayScore = 0,
                            AwayTeam = "CastroTeam",
                            HomeScore = 9,
                            HomeTeam = "Sicaci",
                            Round = 1,
                            TournamentId = 1,
                            Winner = "Home"
                        });
                });

            modelBuilder.Entity("IIS.Data.Entities.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsUser")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int>("UserOrTeam")
                        .HasColumnType("int");

                    b.HasKey("ParticipantId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Participants");

                    b.HasData(
                        new
                        {
                            ParticipantId = 1,
                            IsUser = true,
                            Name = "Daniel Weis",
                            TournamentId = 2,
                            UserOrTeam = 1
                        },
                        new
                        {
                            ParticipantId = 2,
                            IsUser = true,
                            Name = "Walter White",
                            TournamentId = 2,
                            UserOrTeam = 2
                        },
                        new
                        {
                            ParticipantId = 3,
                            IsUser = false,
                            Name = "Sicaci",
                            TournamentId = 1,
                            UserOrTeam = 1
                        },
                        new
                        {
                            ParticipantId = 4,
                            IsUser = false,
                            Name = "CastroTeam",
                            TournamentId = 1,
                            UserOrTeam = 2
                        });
                });

            modelBuilder.Entity("IIS.Data.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Logo")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            Logo = 1,
                            Name = "Sicaci"
                        },
                        new
                        {
                            TeamId = 2,
                            Logo = 2,
                            Name = "CastroTeam"
                        });
                });

            modelBuilder.Entity("IIS.Data.Entities.TeamsInMatch", b =>
                {
                    b.Property<int>("TeamsInMatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Home")
                        .HasColumnType("bit");

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("TeamsInMatchId");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamsInMatches");

                    b.HasData(
                        new
                        {
                            TeamsInMatchId = 1,
                            Home = true,
                            MatchId = 2,
                            TeamId = 1
                        },
                        new
                        {
                            TeamsInMatchId = 2,
                            Home = false,
                            MatchId = 2,
                            TeamId = 2
                        });
                });

            modelBuilder.Entity("IIS.Data.Entities.Tournament", b =>
                {
                    b.Property<int>("TournamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Entry")
                        .HasColumnType("int");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organizer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prize")
                        .HasColumnType("int");

                    b.Property<string>("Referee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sponsors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TournamentId");

                    b.ToTable("Tournaments");

                    b.HasData(
                        new
                        {
                            TournamentId = 1,
                            Capacity = 16,
                            Date = "2019-10-31",
                            Entry = 5,
                            Location = "Bozetechova",
                            Name = "FIT - BIT",
                            Organizer = "Daniel Weis",
                            Prize = 500,
                            Referee = "Adam Pered",
                            Sponsors = "Coca Cola",
                            Time = "14:00",
                            Type = "Duo"
                        },
                        new
                        {
                            TournamentId = 2,
                            Capacity = 8,
                            Date = "2019-10-30",
                            Entry = 100,
                            Location = "Bozetechova",
                            Name = "FIT - MIT",
                            Organizer = "Alfonz Hrozny",
                            Prize = 1000,
                            Referee = "Daniel Weis",
                            Sponsors = "Pepsi, Hyundai",
                            Time = "14:00",
                            Type = "Solo"
                        });
                });

            modelBuilder.Entity("IIS.Data.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "weisko123@azet.sk",
                            FirstName = "Daniel",
                            LastName = "Weis",
                            Password = "d87a969ac02af63d199dbebe2c1ab84f4ab99dc60540cb3365c5b75d8b03e031",
                            TeamId = 1,
                            isAdmin = false
                        },
                        new
                        {
                            UserId = 2,
                            Email = "breaking@bad.bb",
                            FirstName = "Walter",
                            LastName = "White",
                            Password = "13ed070478ef62c3a7baa36c8d042a9d1cdc0fcbb2af93a795f2ad20ad6e9cb5",
                            TeamId = 1,
                            isAdmin = false
                        },
                        new
                        {
                            UserId = 3,
                            Email = "vsetkodobre@gmail.com",
                            FirstName = "Adam",
                            LastName = "Pered",
                            Password = "5c85f802591ce72681063e53818edc5cb666d10e30e896f9a08f92e610509d53",
                            TeamId = 2,
                            isAdmin = true
                        },
                        new
                        {
                            UserId = 4,
                            Email = "js@coco.tv",
                            FirstName = "Jordan",
                            LastName = "Schlansky",
                            Password = "8750b1c70c66ee87a31cede20e17d62a458de31a5f7bbcb5fe5aea08579db229",
                            TeamId = 2,
                            isAdmin = false
                        });
                });

            modelBuilder.Entity("IIS.Data.Entities.UsersInMatch", b =>
                {
                    b.Property<int>("UsersInMatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Home")
                        .HasColumnType("bit");

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UsersInMatchId");

                    b.HasIndex("MatchId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersInMatches");

                    b.HasData(
                        new
                        {
                            UsersInMatchId = 1,
                            Home = true,
                            MatchId = 1,
                            UserId = 1
                        },
                        new
                        {
                            UsersInMatchId = 2,
                            Home = false,
                            MatchId = 1,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("IIS.Data.Statistics", b =>
                {
                    b.Property<int>("StatisticsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Draws")
                        .HasColumnType("int");

                    b.Property<int>("Games")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<int>("Loses")
                        .HasColumnType("int");

                    b.Property<string>("Team")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("StatisticsId");

                    b.HasIndex("TeamId");

                    b.HasIndex("TournamentId");

                    b.HasIndex("UserId");

                    b.ToTable("Statistics");

                    b.HasData(
                        new
                        {
                            StatisticsId = 1,
                            Draws = 1,
                            Games = 2,
                            Goals = 5,
                            Loses = 0,
                            UserId = 1,
                            Wins = 1
                        },
                        new
                        {
                            StatisticsId = 2,
                            Draws = 3,
                            Games = 5,
                            Goals = 0,
                            Loses = 2,
                            UserId = 2,
                            Wins = 0
                        },
                        new
                        {
                            StatisticsId = 3,
                            Draws = 3,
                            Games = 5,
                            Goals = 4,
                            Loses = 2,
                            UserId = 3,
                            Wins = 0
                        },
                        new
                        {
                            StatisticsId = 4,
                            Draws = 0,
                            Games = 0,
                            Goals = 0,
                            Loses = 0,
                            UserId = 4,
                            Wins = 0
                        },
                        new
                        {
                            StatisticsId = 5,
                            Draws = 0,
                            Games = 1,
                            Goals = 9,
                            Loses = 0,
                            Team = "Sicaci",
                            Wins = 1
                        },
                        new
                        {
                            StatisticsId = 6,
                            Draws = 0,
                            Games = 2,
                            Goals = 1,
                            Loses = 1,
                            Team = "CastroTeam",
                            Wins = 1
                        },
                        new
                        {
                            StatisticsId = 7,
                            Draws = 1,
                            Games = 1,
                            Goals = 1,
                            Loses = 0,
                            TournamentId = 2,
                            UserId = 1,
                            Wins = 0
                        },
                        new
                        {
                            StatisticsId = 8,
                            Draws = 1,
                            Games = 1,
                            Goals = 1,
                            Loses = 0,
                            TournamentId = 2,
                            UserId = 2,
                            Wins = 0
                        },
                        new
                        {
                            StatisticsId = 9,
                            Draws = 0,
                            Games = 1,
                            Goals = 9,
                            Loses = 0,
                            Team = "Sicaci",
                            TournamentId = 1,
                            Wins = 1
                        },
                        new
                        {
                            StatisticsId = 10,
                            Draws = 0,
                            Games = 1,
                            Goals = 0,
                            Loses = 1,
                            Team = "CastroTeam",
                            TournamentId = 1,
                            Wins = 0
                        });
                });

            modelBuilder.Entity("IIS.Data.Entities.Match", b =>
                {
                    b.HasOne("IIS.Data.Entities.User", "Away")
                        .WithMany()
                        .HasForeignKey("AwayUserId");

                    b.HasOne("IIS.Data.Entities.User", "Home")
                        .WithMany()
                        .HasForeignKey("HomeUserId");

                    b.HasOne("IIS.Data.Entities.Tournament", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IIS.Data.Entities.Participant", b =>
                {
                    b.HasOne("IIS.Data.Entities.Tournament", null)
                        .WithMany("Participants")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("IIS.Data.Entities.TeamsInMatch", b =>
                {
                    b.HasOne("IIS.Data.Entities.Match", "Match")
                        .WithMany("TeamsInMatches")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IIS.Data.Entities.Team", "Team")
                        .WithMany("TeamsInMatches")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("IIS.Data.Entities.User", b =>
                {
                    b.HasOne("IIS.Data.Entities.Team", "Team")
                        .WithMany("Users")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("IIS.Data.Entities.UsersInMatch", b =>
                {
                    b.HasOne("IIS.Data.Entities.Match", "Match")
                        .WithMany("UsersInMatches")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IIS.Data.Entities.User", "User")
                        .WithMany("UsersInMatches")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("IIS.Data.Statistics", b =>
                {
                    b.HasOne("IIS.Data.Entities.Team", null)
                        .WithMany("Statistics")
                        .HasForeignKey("TeamId");

                    b.HasOne("IIS.Data.Entities.Tournament", "Tournament")
                        .WithMany("Statistics")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IIS.Data.Entities.User", "User")
                        .WithMany("Statistics")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
