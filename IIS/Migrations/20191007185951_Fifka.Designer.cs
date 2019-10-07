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
    [Migration("20191007185951_Fifka")]
    partial class Fifka
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
                    b.Property<int>("MatchID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwayScore")
                        .HasColumnType("int");

                    b.Property<string>("AwayTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("HomeScore")
                        .HasColumnType("int");

                    b.Property<string>("HomeTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TournamentID")
                        .HasColumnType("int");

                    b.HasKey("MatchID");

                    b.HasIndex("TournamentID");

                    b.ToTable("Matches");

                    b.HasData(
                        new
                        {
                            MatchID = 1,
                            AwayScore = 0,
                            AwayTeam = "Imel",
                            Date = new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HomeScore = 1,
                            HomeTeam = "Hurbanovo"
                        });
                });

            modelBuilder.Entity("IIS.Data.Entities.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Logo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamID");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamID = 1,
                            Name = "Sicaci"
                        });
                });

            modelBuilder.Entity("IIS.Data.Entities.TeamsInMatch", b =>
                {
                    b.Property<int>("TeamsInMatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MatchID")
                        .HasColumnType("int");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("TeamsInMatchId");

                    b.HasIndex("MatchID");

                    b.HasIndex("TeamID");

                    b.ToTable("TeamsInMatch");
                });

            modelBuilder.Entity("IIS.Data.Entities.TeamsInTournament", b =>
                {
                    b.Property<int>("TeamsInTournamentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentID")
                        .HasColumnType("int");

                    b.HasKey("TeamsInTournamentID");

                    b.HasIndex("TeamID");

                    b.HasIndex("TournamentID");

                    b.ToTable("TeamsInTournament");
                });

            modelBuilder.Entity("IIS.Data.Entities.Tournament", b =>
                {
                    b.Property<int>("TournamentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Entry")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prize")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("TournamentID");

                    b.ToTable("Tournaments");

                    b.HasData(
                        new
                        {
                            TournamentID = 1,
                            Capacity = 800,
                            Date = new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Entry = 600,
                            Name = "FIT - BIT",
                            Prize = 500,
                            Type = 1
                        });
                });

            modelBuilder.Entity("IIS.Data.Entities.User", b =>
                {
                    b.Property<int>("UserID")
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

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "weisthejew@azet.sk",
                            FirstName = "Daniel",
                            LastName = "Weis",
                            Password = "pepemobil123"
                        });
                });

            modelBuilder.Entity("IIS.Data.Entities.UsersInMatch", b =>
                {
                    b.Property<int>("UsersInMatchID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MatchID")
                        .HasColumnType("int");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("UsersInMatchID");

                    b.HasIndex("MatchID");

                    b.HasIndex("TeamID");

                    b.HasIndex("UserID");

                    b.ToTable("UsersInMatch");
                });

            modelBuilder.Entity("IIS.Data.Statistics", b =>
                {
                    b.Property<int>("StatisticsID")
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

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("StatisticsID");

                    b.HasIndex("TeamID");

                    b.HasIndex("UserID");

                    b.ToTable("Statistics");

                    b.HasData(
                        new
                        {
                            StatisticsID = 1,
                            Draws = 1,
                            Games = 2,
                            Goals = 5,
                            Loses = 0,
                            Wins = 1
                        });
                });

            modelBuilder.Entity("IIS.Data.Entities.Match", b =>
                {
                    b.HasOne("IIS.Data.Entities.Tournament", null)
                        .WithMany("Matches")
                        .HasForeignKey("TournamentID");
                });

            modelBuilder.Entity("IIS.Data.Entities.TeamsInMatch", b =>
                {
                    b.HasOne("IIS.Data.Entities.Match", "Match")
                        .WithMany("TeamsInMatches")
                        .HasForeignKey("MatchID");

                    b.HasOne("IIS.Data.Entities.Team", "Team")
                        .WithMany("TeamsInMatches")
                        .HasForeignKey("TeamID");
                });

            modelBuilder.Entity("IIS.Data.Entities.TeamsInTournament", b =>
                {
                    b.HasOne("IIS.Data.Entities.Team", "Team")
                        .WithMany("TeamsInTournaments")
                        .HasForeignKey("TeamID");

                    b.HasOne("IIS.Data.Entities.Tournament", "Tournament")
                        .WithMany("TeamsInTournaments")
                        .HasForeignKey("TournamentID");
                });

            modelBuilder.Entity("IIS.Data.Entities.UsersInMatch", b =>
                {
                    b.HasOne("IIS.Data.Entities.Match", null)
                        .WithMany("UsersInMatches")
                        .HasForeignKey("MatchID");

                    b.HasOne("IIS.Data.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamID");

                    b.HasOne("IIS.Data.Entities.User", "User")
                        .WithMany("UsersInMatches")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("IIS.Data.Statistics", b =>
                {
                    b.HasOne("IIS.Data.Entities.Team", null)
                        .WithMany("Statistics")
                        .HasForeignKey("TeamID");

                    b.HasOne("IIS.Data.Entities.User", null)
                        .WithMany("Statistics")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
