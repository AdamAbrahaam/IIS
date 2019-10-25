using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class initial : Migration
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
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
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
                        name: "FK_Statistics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Prize = table.Column<int>(nullable: false),
                    Entry = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    OrganizerUserId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                    table.ForeignKey(
                        name: "FK_Tournaments_Users_OrganizerUserId",
                        column: x => x.OrganizerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTeam = table.Column<string>(nullable: true),
                    AwayTeam = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    HomeScore = table.Column<int>(nullable: false),
                    AwayScore = table.Column<int>(nullable: false),
                    TournamentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamsInTournament",
                columns: table => new
                {
                    TeamsInTournamentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsInTournament", x => x.TeamsInTournamentId);
                    table.ForeignKey(
                        name: "FK_TeamsInTournament_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamsInTournament_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamsInMatch",
                columns: table => new
                {
                    TeamsInMatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(nullable: true),
                    MatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsInMatch", x => x.TeamsInMatchId);
                    table.ForeignKey(
                        name: "FK_TeamsInMatch_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamsInMatch_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersInMatch",
                columns: table => new
                {
                    UsersInMatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: true),
                    MatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInMatch", x => x.UsersInMatchId);
                    table.ForeignKey(
                        name: "FK_UsersInMatch_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersInMatch_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersInMatch_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "AwayScore", "AwayTeam", "Date", "HomeScore", "HomeTeam", "TournamentId" },
                values: new object[] { 1, 0, "Imel", new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Hurbanovo", null });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "Draws", "Games", "Goals", "Loses", "TeamId", "UserId", "Wins" },
                values: new object[] { 1, 1, 2, 5, 0, null, null, 1 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Logo", "Name" },
                values: new object[] { 1, null, "Sicaci" });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "TournamentId", "Capacity", "Date", "Entry", "Location", "Name", "OrganizerUserId", "Prize", "Type" },
                values: new object[,]
                {
                    { 1, 800, new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 600, "Bozetechova", "FIT - BIT", null, 500, 1 },
                    { 2, 802, new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6002, "Bozetechova2", "FIT - BIT2", null, 5002, 1 },
                    { 3, 803, new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6003, "Bozetechova3", "FIT - BIT3", null, 5003, 0 },
                    { 4, 804, new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 604, "Bozetechova4", "FIT - BIT4", null, 504, 1 },
                    { 5, 805, new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 605, "Bozetechova5", "FIT - BIT5", null, 505, 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "weisthejew@azet.sk", "Daniel", "Weis", "pepemobil123" },
                    { 2, "breaking@bad.bb", "Walter", "White", "asd" }
                });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "Draws", "Games", "Goals", "Loses", "TeamId", "UserId", "Wins" },
                values: new object[] { 2, 3, 5, 0, 2, 1, 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TournamentId",
                table: "Matches",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_TeamId",
                table: "Statistics",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInMatch_MatchId",
                table: "TeamsInMatch",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInMatch_TeamId",
                table: "TeamsInMatch",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInTournament_TeamId",
                table: "TeamsInTournament",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInTournament_TournamentId",
                table: "TeamsInTournament",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_OrganizerUserId",
                table: "Tournaments",
                column: "OrganizerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInMatch_MatchId",
                table: "UsersInMatch",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInMatch_TeamId",
                table: "UsersInMatch",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInMatch_UserId",
                table: "UsersInMatch",
                column: "UserId");
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
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
