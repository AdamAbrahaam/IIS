using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class bldr : Migration
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
                    Logo = table.Column<int>(nullable: false)
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
                    Type = table.Column<string>(nullable: true)
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
                    TeamId = table.Column<int>(nullable: true),
                    isAdmin = table.Column<bool>(nullable: false)
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
                name: "Participants",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UserOrTeam = table.Column<int>(nullable: false),
                    IsUser = table.Column<bool>(nullable: false),
                    TournamentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ParticipantId);
                    table.ForeignKey(
                        name: "FK_Participants_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
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
                    Round = table.Column<int>(nullable: false),
                    Winner = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersInMatches_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "Draws", "Games", "Goals", "Loses", "Team", "TeamId", "TournamentId", "UserId", "Wins" },
                values: new object[,]
                {
                    { 5, 0, 1, 9, 0, "Sicaci", null, null, null, 1 },
                    { 6, 0, 2, 1, 1, "CastroTeam", null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Logo", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Sicaci" },
                    { 2, 2, "CastroTeam" }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "TournamentId", "Capacity", "Date", "Entry", "Info", "Location", "Name", "Organizer", "Prize", "Referee", "Sponsors", "Time", "Type" },
                values: new object[,]
                {
                    { 1, 16, "2019-10-31", 5, null, "Bozetechova", "FIT - BIT", "Daniel Weis", 500, "Adam Pered", "Coca Cola", "14:00", "Duo" },
                    { 2, 8, "2019-10-30", 100, null, "Bozetechova", "FIT - MIT", "Alfonz Hrozny", 1000, "Daniel Weis", "Pepsi, Hyundai", "14:00", "Solo" }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "AwayScore", "AwayTeam", "AwayUserId", "HomeScore", "HomeTeam", "HomeUserId", "Round", "TournamentId", "Winner" },
                values: new object[] { 2, 0, "CastroTeam", null, 9, "Sicaci", null, 1, 1, "Home" });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "ParticipantId", "IsUser", "Name", "TournamentId", "UserOrTeam" },
                values: new object[,]
                {
                    { 3, false, "Sicaci", 1, 1 },
                    { 4, false, "CastroTeam", 1, 2 },
                    { 1, true, "Daniel Weis", 2, 1 },
                    { 2, true, "Walter White", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "Draws", "Games", "Goals", "Loses", "Team", "TeamId", "TournamentId", "UserId", "Wins" },
                values: new object[,]
                {
                    { 9, 0, 1, 9, 0, "Sicaci", null, 1, null, 1 },
                    { 10, 0, 1, 0, 1, "CastroTeam", null, 1, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password", "TeamId", "isAdmin" },
                values: new object[,]
                {
                    { 1, "weisko123@azet.sk", "Daniel", "Weis", "d87a969ac02af63d199dbebe2c1ab84f4ab99dc60540cb3365c5b75d8b03e031", 1, false },
                    { 2, "breaking@bad.bb", "Walter", "White", "13ed070478ef62c3a7baa36c8d042a9d1cdc0fcbb2af93a795f2ad20ad6e9cb5", 1, false },
                    { 3, "vsetkodobre@gmail.com", "Adam", "Pered", "5c85f802591ce72681063e53818edc5cb666d10e30e896f9a08f92e610509d53", 2, true },
                    { 4, "js@coco.tv", "Jordan", "Schlansky", "8750b1c70c66ee87a31cede20e17d62a458de31a5f7bbcb5fe5aea08579db229", 2, false }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "AwayScore", "AwayTeam", "AwayUserId", "HomeScore", "HomeTeam", "HomeUserId", "Round", "TournamentId", "Winner" },
                values: new object[] { 1, 2, null, 2, 1, null, 1, 1, 2, "Away" });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "Draws", "Games", "Goals", "Loses", "Team", "TeamId", "TournamentId", "UserId", "Wins" },
                values: new object[,]
                {
                    { 1, 1, 2, 5, 0, null, null, null, 1, 1 },
                    { 7, 1, 1, 1, 0, null, null, 2, 1, 0 },
                    { 2, 3, 5, 0, 2, null, null, null, 2, 0 },
                    { 8, 1, 1, 1, 0, null, null, 2, 2, 0 },
                    { 3, 3, 5, 4, 2, null, null, null, 3, 0 },
                    { 4, 0, 0, 0, 0, null, null, null, 4, 0 }
                });

            migrationBuilder.InsertData(
                table: "TeamsInMatches",
                columns: new[] { "TeamsInMatchId", "Home", "MatchId", "TeamId" },
                values: new object[,]
                {
                    { 1, true, 2, 1 },
                    { 2, false, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "UsersInMatches",
                columns: new[] { "UsersInMatchId", "Home", "MatchId", "UserId" },
                values: new object[] { 1, true, 1, 1 });

            migrationBuilder.InsertData(
                table: "UsersInMatches",
                columns: new[] { "UsersInMatchId", "Home", "MatchId", "UserId" },
                values: new object[] { 2, false, 1, 2 });

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
                name: "IX_Participants_TournamentId",
                table: "Participants",
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
                name: "Participants");

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
