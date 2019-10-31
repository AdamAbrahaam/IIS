using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Participants",
                table: "Tournaments");

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

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "MatchId", "AwayScore", "AwayTeam", "AwayUserId", "Date", "HomeScore", "HomeTeam", "HomeUserId", "Time", "TournamentId" },
                values: new object[] { 2, 0, "CastroTeam", null, "2019-10-31", 9, "Sicaci", null, "14:00", 1 });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "ParticipantId", "IsUser", "Name", "TournamentId", "UserOrTeam" },
                values: new object[,]
                {
                    { 3, false, "Sicaci", 1, 1 },
                    { 4, false, "CastroTeam", 1, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Statistics",
                keyColumn: "StatisticsId",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Statistics",
                keyColumn: "StatisticsId",
                keyValue: 2,
                columns: new[] { "TeamId", "UserId" },
                values: new object[] { null, 2 });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "Draws", "Games", "Goals", "Loses", "Team", "TeamId", "TournamentId", "UserId", "Wins" },
                values: new object[,]
                {
                    { 5, 0, 1, 9, 0, "Sicaci", null, null, null, 1 },
                    { 6, 0, 2, 1, 1, "CastroTeam", null, null, null, 1 },
                    { 9, 0, 1, 9, 0, "Sicaci", null, 1, null, 1 },
                    { 10, 0, 1, 0, 1, "CastroTeam", null, 1, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Logo", "Name" },
                values: new object[] { 2, null, "CastroTeam" });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                columns: new[] { "Date", "Referee" },
                values: new object[] { "2019-10-31", "Adam Pered" });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "TournamentId", "Capacity", "Date", "Entry", "Info", "Location", "Name", "Organizer", "Prize", "Referee", "Sponsors", "Time", "Type" },
                values: new object[] { 2, 8, "2019-10-30", 100, null, "Bozetechova", "FIT - MIT", "Alfonz Hrozny", 1000, "Daniel Weis", "Pepsi, Hyundai", "14:00", "Solo" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "Password", "TeamId" },
                values: new object[] { "weisko123@azet.sk", "purkyne", 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Password", "TeamId" },
                values: new object[] { "netflix", 1 });

            migrationBuilder.InsertData(
                table: "UsersInMatches",
                columns: new[] { "UsersInMatchId", "Home", "MatchId", "UserId" },
                values: new object[] { 2, false, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                columns: new[] { "AwayScore", "AwayTeam", "AwayUserId", "Date", "HomeTeam", "HomeUserId", "Time", "TournamentId" },
                values: new object[] { 1, null, 2, "2019-10-30", null, 1, "14:00", 2 });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "ParticipantId", "IsUser", "Name", "TournamentId", "UserOrTeam" },
                values: new object[,]
                {
                    { 1, true, "Daniel Weis", 2, 1 },
                    { 2, true, "Walter White", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "Draws", "Games", "Goals", "Loses", "Team", "TeamId", "TournamentId", "UserId", "Wins" },
                values: new object[,]
                {
                    { 7, 1, 1, 1, 0, null, null, 2, 1, 0 },
                    { 8, 1, 1, 1, 0, null, null, 2, 2, 0 }
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
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password", "TeamId" },
                values: new object[,]
                {
                    { 3, "vsetkodobre@gmail.com", "Adam", "Pered", "heslicko", 2 },
                    { 4, "fidelio@gmail.com", "Alfonz", "Hrozny", "castro123", 2 }
                });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "Draws", "Games", "Goals", "Loses", "Team", "TeamId", "TournamentId", "UserId", "Wins" },
                values: new object[] { 3, 3, 5, 4, 2, null, null, null, 3, 0 });

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "Draws", "Games", "Goals", "Loses", "Team", "TeamId", "TournamentId", "UserId", "Wins" },
                values: new object[] { 4, 0, 0, 0, 0, null, null, null, 4, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_TournamentId",
                table: "Participants",
                column: "TournamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "StatisticsId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "StatisticsId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "StatisticsId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "StatisticsId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "StatisticsId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "StatisticsId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "StatisticsId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "StatisticsId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TeamsInMatches",
                keyColumn: "TeamsInMatchId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TeamsInMatches",
                keyColumn: "TeamsInMatchId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UsersInMatches",
                keyColumn: "UsersInMatchId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "Participants",
                table: "Tournaments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "TournamentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                columns: new[] { "AwayScore", "AwayTeam", "AwayUserId", "Date", "HomeTeam", "HomeUserId", "Time", "TournamentId" },
                values: new object[] { 0, "Imel", null, null, "Hurbanovo", null, null, null });

            migrationBuilder.UpdateData(
                table: "Statistics",
                keyColumn: "StatisticsId",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Statistics",
                keyColumn: "StatisticsId",
                keyValue: 2,
                columns: new[] { "TeamId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                columns: new[] { "Date", "Referee" },
                values: new object[] { "22-10-2020", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "Password", "TeamId" },
                values: new object[] { "weisthejew@azet.sk", "pepemobil123", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Password", "TeamId" },
                values: new object[] { "asd", null });
        }
    }
}
