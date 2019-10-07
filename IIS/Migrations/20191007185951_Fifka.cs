using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class Fifka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Prize = table.Column<int>(nullable: false),
                    Entry = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTeam = table.Column<string>(nullable: true),
                    AwayTeam = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    HomeScore = table.Column<int>(nullable: false),
                    AwayScore = table.Column<int>(nullable: false),
                    TournamentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchID);
                    table.ForeignKey(
                        name: "FK_Matches_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamsInTournament",
                columns: table => new
                {
                    TeamsInTournamentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentID = table.Column<int>(nullable: true),
                    TeamID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsInTournament", x => x.TeamsInTournamentID);
                    table.ForeignKey(
                        name: "FK_TeamsInTournament_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamsInTournament_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    StatisticsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goals = table.Column<int>(nullable: false),
                    Games = table.Column<int>(nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Draws = table.Column<int>(nullable: false),
                    Loses = table.Column<int>(nullable: false),
                    TeamID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.StatisticsID);
                    table.ForeignKey(
                        name: "FK_Statistics_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statistics_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamsInMatch",
                columns: table => new
                {
                    TeamsInMatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<int>(nullable: true),
                    MatchID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsInMatch", x => x.TeamsInMatchId);
                    table.ForeignKey(
                        name: "FK_TeamsInMatch_Matches_MatchID",
                        column: x => x.MatchID,
                        principalTable: "Matches",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamsInMatch_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersInMatch",
                columns: table => new
                {
                    UsersInMatchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: true),
                    TeamID = table.Column<int>(nullable: true),
                    MatchID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInMatch", x => x.UsersInMatchID);
                    table.ForeignKey(
                        name: "FK_UsersInMatch_Matches_MatchID",
                        column: x => x.MatchID,
                        principalTable: "Matches",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersInMatch_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersInMatch_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchID", "AwayScore", "AwayTeam", "Date", "HomeScore", "HomeTeam", "TournamentID" },
                values: new object[] { 1, 0, "Imel", new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hurbanovo", null });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsID", "Draws", "Games", "Goals", "Loses", "TeamID", "UserID", "Wins" },
                values: new object[] { 1, 1, 2, 5, 0, null, null, 1 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "Logo", "Name" },
                values: new object[] { 1, null, "Sicaci" });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "TournamentID", "Capacity", "Date", "Entry", "Location", "Name", "Prize", "Type" },
                values: new object[] { 1, 800, new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 600, null, "FIT - BIT", 500, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, "weisthejew@azet.sk", "Daniel", "Weis", "pepemobil123" });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TournamentID",
                table: "Matches",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_TeamID",
                table: "Statistics",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_UserID",
                table: "Statistics",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInMatch_MatchID",
                table: "TeamsInMatch",
                column: "MatchID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInMatch_TeamID",
                table: "TeamsInMatch",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInTournament_TeamID",
                table: "TeamsInTournament",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInTournament_TournamentID",
                table: "TeamsInTournament",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInMatch_MatchID",
                table: "UsersInMatch",
                column: "MatchID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInMatch_TeamID",
                table: "UsersInMatch",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInMatch_UserID",
                table: "UsersInMatch",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "TeamsInMatch");

            migrationBuilder.DropTable(
                name: "TeamsInTournament");

            migrationBuilder.DropTable(
                name: "UsersInMatch");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
