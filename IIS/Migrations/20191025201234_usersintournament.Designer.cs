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
    [Migration("20191025201234_usersintournament")]
    partial class usersintournament
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

                    b.HasKey("MatchId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Matches");

                    b.HasData(
                        new
                        {
                            MatchId = 1,
                            AwayScore = 0,
                            AwayTeam = "Imel",
                            Date = new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HomeScore = 1,
                            HomeTeam = "Hurbanovo"
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

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("TeamsInMatchId");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamsInMatch");
                });

            modelBuilder.Entity("IIS.Data.Entities.TeamsInTournament", b =>
                {
                    b.Property<int>("TeamsInTournamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("TeamsInTournamentId");

                    b.HasIndex("TeamId");

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

                    b.Property<string>("Sponsors")
                        .HasColumnType("nvarchar(max)");

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
                            OrganizerUserId = 1,
                            Prize = 500,
                            Sponsors = "asd,dsa",
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
                            Sponsors = "asd,dsa",
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
                            Sponsors = "asd,dsa",
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
                            Sponsors = "asd,dsa",
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
                            Sponsors = "asd,dsa",
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

                    b.Property<int?>("MatchId")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UsersInMatchId");

                    b.HasIndex("MatchId");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersInMatch");
                });

            modelBuilder.Entity("IIS.Data.Entities.UsersInTournament", b =>
                {
                    b.Property<int>("UsersInTournamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UsersInTournamentId");

                    b.HasIndex("TournamentId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersInTournament");
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

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("StatisticsId");

                    b.HasIndex("TeamId");

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
                    b.HasOne("IIS.Data.Entities.Tournament", null)
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

            modelBuilder.Entity("IIS.Data.Entities.TeamsInTournament", b =>
                {
                    b.HasOne("IIS.Data.Entities.Team", "Team")
                        .WithMany("TeamsInTournaments")
                        .HasForeignKey("TeamId");

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
                        .HasForeignKey("MatchId");

                    b.HasOne("IIS.Data.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId");

                    b.HasOne("IIS.Data.Entities.User", "User")
                        .WithMany("UsersInMatches")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("IIS.Data.Entities.UsersInTournament", b =>
                {
                    b.HasOne("IIS.Data.Entities.Tournament", "Tournament")
                        .WithMany("UsersInTournaments")
                        .HasForeignKey("TournamentId");

                    b.HasOne("IIS.Data.Entities.User", "User")
                        .WithMany("UsersInTournaments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("IIS.Data.Statistics", b =>
                {
                    b.HasOne("IIS.Data.Entities.Team", "Team")
                        .WithMany("Statistics")
                        .HasForeignKey("TeamId");

                    b.HasOne("IIS.Data.Entities.User", "User")
                        .WithMany("Statistics")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
