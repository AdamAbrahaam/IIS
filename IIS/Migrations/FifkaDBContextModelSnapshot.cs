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

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("MatchID");

                    b.HasIndex("TournamentId");

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

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("TeamsInTournamentID");

                    b.HasIndex("TeamID");

                    b.HasIndex("TournamentId");

                    b.ToTable("TeamsInTournament");
                });

            modelBuilder.Entity("IIS.Data.Entities.Tournament", b =>
                {
                    b.Property<int>("TournamentId")
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

                    b.Property<int?>("OrganizerUserId")
                        .HasColumnType("int");

                    b.Property<int>("Prize")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("TournamentId");

                    b.HasIndex("OrganizerUserId");

                    b.ToTable("Tournaments");

                    b.HasData(
                        new
                        {
                            TournamentId = 1,
                            Capacity = 800,
                            Date = new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Entry = 600,
                            Location = "Bozetechova",
                            Name = "FIT - BIT",
                            Prize = 500,
                            Type = 1
                        },
                        new
                        {
                            TournamentId = 2,
                            Capacity = 802,
                            Date = new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Entry = 6002,
                            Location = "Bozetechova2",
                            Name = "FIT - BIT2",
                            Prize = 5002,
                            Type = 1
                        },
                        new
                        {
                            TournamentId = 3,
                            Capacity = 803,
                            Date = new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Entry = 6003,
                            Location = "Bozetechova3",
                            Name = "FIT - BIT3",
                            Prize = 5003,
                            Type = 0
                        },
                        new
                        {
                            TournamentId = 4,
                            Capacity = 804,
                            Date = new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Entry = 604,
                            Location = "Bozetechova4",
                            Name = "FIT - BIT4",
                            Prize = 504,
                            Type = 1
                        },
                        new
                        {
                            TournamentId = 5,
                            Capacity = 805,
                            Date = new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Entry = 605,
                            Location = "Bozetechova5",
                            Name = "FIT - BIT5",
                            Prize = 505,
                            Type = 0
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

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
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

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UsersInMatchID");

                    b.HasIndex("MatchID");

                    b.HasIndex("TeamID");

                    b.HasIndex("UserId");

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

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("StatisticsID");

                    b.HasIndex("TeamID");

                    b.HasIndex("UserId");

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
                        .HasForeignKey("TournamentId");
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
                        .HasForeignKey("TournamentId");
                });

            modelBuilder.Entity("IIS.Data.Entities.Tournament", b =>
                {
                    b.HasOne("IIS.Data.Entities.User", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerUserId");
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
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("IIS.Data.Statistics", b =>
                {
                    b.HasOne("IIS.Data.Entities.Team", null)
                        .WithMany("Statistics")
                        .HasForeignKey("TeamID");

                    b.HasOne("IIS.Data.Entities.User", null)
                        .WithMany("Statistics")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
