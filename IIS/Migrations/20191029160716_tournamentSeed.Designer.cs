﻿// <auto-generated />
using System;
using IIS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IIS.Migrations
{
    [DbContext(typeof(FifkaDBContext))]
    [Migration("20191029160716_tournamentSeed")]
    partial class tournamentSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HomeScore")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Matches");

                    b.HasData(
                        new
                        {
                            MatchId = 1,
                            AwayScore = 0,
                            HomeScore = 1
                        });
                });

            modelBuilder.Entity("IIS.Data.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Logo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            Name = "Sicaci"
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

                    b.Property<string>("Participants")
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
                            Date = "22-10-2020",
                            Entry = 5,
                            Location = "Bozetechova",
                            Name = "FIT - BIT",
                            Organizer = "Daniel Weis",
                            Prize = 500,
                            Sponsors = "Coca Cola",
                            Time = "14:00",
                            Type = "Duo"
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

                    b.HasKey("UserId");

                    b.HasIndex("TeamId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "weisthejew@azet.sk",
                            FirstName = "Daniel",
                            LastName = "Weis",
                            Password = "pepemobil123"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "breaking@bad.bb",
                            FirstName = "Walter",
                            LastName = "White",
                            Password = "asd"
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
                            Wins = 1
                        },
                        new
                        {
                            StatisticsId = 2,
                            Draws = 3,
                            Games = 5,
                            Goals = 0,
                            Loses = 2,
                            TeamId = 1,
                            UserId = 1,
                            Wins = 0
                        });
                });

            modelBuilder.Entity("IIS.Data.Entities.Match", b =>
                {
                    b.HasOne("IIS.Data.Entities.Tournament", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("IIS.Data.Entities.TeamsInMatch", b =>
                {
                    b.HasOne("IIS.Data.Entities.Match", "Match")
                        .WithMany("TeamsInMatches")
                        .HasForeignKey("MatchId");

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
                        .HasForeignKey("MatchId");

                    b.HasOne("IIS.Data.Entities.User", "User")
                        .WithMany("UsersInMatches")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("IIS.Data.Statistics", b =>
                {
                    b.HasOne("IIS.Data.Entities.Team", "Team")
                        .WithMany("Statistics")
                        .HasForeignKey("TeamId");

                    b.HasOne("IIS.Data.Entities.Tournament", "Tournament")
                        .WithMany("Statistics")
                        .HasForeignKey("TournamentId");

                    b.HasOne("IIS.Data.Entities.User", "User")
                        .WithMany("Statistics")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
