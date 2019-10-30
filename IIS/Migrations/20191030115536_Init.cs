using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true),
                    Prize = table.Column<int>(nullable: false),
                    Entry = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    Organizer = table.Column<string>(nullable: true),
                    Referee = table.Column<string>(nullable: true),
                    Sponsors = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Participants = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeScore = table.Column<int>(nullable: false),
                    AwayScore = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    HomeUserId = table.Column<int>(nullable: true),
                    AwayUserId = table.Column<int>(nullable: true),
                    HomeTeam = table.Column<string>(nullable: true),
                    AwayTeam = table.Column<string>(nullable: true),
                    TournamentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Users_AwayUserId",
                        column: x => x.AwayUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Users_HomeUserId",
                        column: x => x.HomeUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    StatisticsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goals = table.Column<int>(nullable: false),
                    Games = table.Column<int>(nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Draws = table.Column<int>(nullable: false),
                    Loses = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    Team = table.Column<string>(nullable: true),
                    TournamentId = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.StatisticsId);
                    table.ForeignKey(
                        name: "FK_Statistics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statistics_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statistics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamsInMatches",
                columns: table => new
                {
                    TeamsInMatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Home = table.Column<bool>(nullable: false),
                    TeamId = table.Column<int>(nullable: true),
                    MatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsInMatches", x => x.TeamsInMatchId);
                    table.ForeignKey(
                        name: "FK_TeamsInMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamsInMatches_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersInMatches",
                columns: table => new
                {
                    UsersInMatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Home = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    MatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInMatches", x => x.UsersInMatchId);
                    table.ForeignKey(
                        name: "FK_UsersInMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersInMatches_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "AwayScore", "AwayTeam", "AwayUserId", "Date", "HomeScore", "HomeTeam", "HomeUserId", "Time", "TournamentId" },
                values: new object[] { 1, 0, "Imel", null, null, 1, "Hurbanovo", null, null, null });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "Draws", "Games", "Goals", "Loses", "Team", "TeamId", "TournamentId", "UserId", "Wins" },
                values: new object[] { 1, 1, 2, 5, 0, null, null, null, null, 1 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Logo", "Name" },
                values: new object[] { 1, null, "Sicaci" });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "TournamentId", "Capacity", "Date", "Entry", "Info", "Location", "Name", "Organizer", "Participants", "Prize", "Referee", "Sponsors", "Time", "Type" },
                values: new object[] { 1, 16, "22-10-2020", 5, null, "Bozetechova", "FIT - BIT", "Daniel Weis", null, 500, null, "Coca Cola", "14:00", "Duo" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password", "TeamId" },
                values: new object[,]
                {
                    { 1, "weisthejew@azet.sk", "Daniel", "Weis", "pepemobil123", null },
                    { 2, "breaking@bad.bb", "Walter", "White", "asd", null }
                });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "Draws", "Games", "Goals", "Loses", "Team", "TeamId", "TournamentId", "UserId", "Wins" },
                values: new object[] { 2, 3, 5, 0, 2, null, 1, null, 1, 0 });

            migrationBuilder.InsertData(
                table: "UsersInMatches",
                columns: new[] { "UsersInMatchId", "Home", "MatchId", "UserId" },
                values: new object[] { 1, true, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayUserId",
                table: "Matches",
                column: "AwayUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeUserId",
                table: "Matches",
                column: "HomeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TournamentId",
                table: "Matches",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_TeamId",
                table: "Statistics",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_TournamentId",
                table: "Statistics",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInMatches_MatchId",
                table: "TeamsInMatches",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInMatches_TeamId",
                table: "TeamsInMatches",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInMatches_MatchId",
                table: "UsersInMatches",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInMatches_UserId",
                table: "UsersInMatches",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "TeamsInMatches");

            migrationBuilder.DropTable(
                name: "UsersInMatches");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
