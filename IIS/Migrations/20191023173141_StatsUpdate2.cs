using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class StatsUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Teams_TeamID",
                table: "Statistics");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInMatch_Matches_MatchID",
                table: "TeamsInMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInMatch_Teams_TeamID",
                table: "TeamsInMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInTournament_Teams_TeamID",
                table: "TeamsInTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMatch_Matches_MatchID",
                table: "UsersInMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMatch_Teams_TeamID",
                table: "UsersInMatch");

            migrationBuilder.RenameColumn(
                name: "TeamID",
                table: "UsersInMatch",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "MatchID",
                table: "UsersInMatch",
                newName: "MatchId");

            migrationBuilder.RenameColumn(
                name: "UsersInMatchID",
                table: "UsersInMatch",
                newName: "UsersInMatchId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInMatch_TeamID",
                table: "UsersInMatch",
                newName: "IX_UsersInMatch_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInMatch_MatchID",
                table: "UsersInMatch",
                newName: "IX_UsersInMatch_MatchId");

            migrationBuilder.RenameColumn(
                name: "TeamID",
                table: "TeamsInTournament",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "TeamsInTournamentID",
                table: "TeamsInTournament",
                newName: "TeamsInTournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInTournament_TeamID",
                table: "TeamsInTournament",
                newName: "IX_TeamsInTournament_TeamId");

            migrationBuilder.RenameColumn(
                name: "TeamID",
                table: "TeamsInMatch",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "MatchID",
                table: "TeamsInMatch",
                newName: "MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInMatch_TeamID",
                table: "TeamsInMatch",
                newName: "IX_TeamsInMatch_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInMatch_MatchID",
                table: "TeamsInMatch",
                newName: "IX_TeamsInMatch_MatchId");

            migrationBuilder.RenameColumn(
                name: "TeamID",
                table: "Teams",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "TeamID",
                table: "Statistics",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "StatisticsID",
                table: "Statistics",
                newName: "StatisticsId");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_TeamID",
                table: "Statistics",
                newName: "IX_Statistics_TeamId");

            migrationBuilder.RenameColumn(
                name: "MatchID",
                table: "Matches",
                newName: "MatchId");

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "StatisticsId", "Draws", "Games", "Goals", "Loses", "TeamId", "UserId", "Wins" },
                values: new object[] { 2, 3, 5, 0, 2, 1, 1, 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Teams_TeamId",
                table: "Statistics",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInMatch_Matches_MatchId",
                table: "TeamsInMatch",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInMatch_Teams_TeamId",
                table: "TeamsInMatch",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInTournament_Teams_TeamId",
                table: "TeamsInTournament",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInMatch_Matches_MatchId",
                table: "UsersInMatch",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInMatch_Teams_TeamId",
                table: "UsersInMatch",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Teams_TeamId",
                table: "Statistics");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInMatch_Matches_MatchId",
                table: "TeamsInMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInMatch_Teams_TeamId",
                table: "TeamsInMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInTournament_Teams_TeamId",
                table: "TeamsInTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMatch_Matches_MatchId",
                table: "UsersInMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMatch_Teams_TeamId",
                table: "UsersInMatch");

            migrationBuilder.DeleteData(
                table: "Statistics",
                keyColumn: "StatisticsId",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "UsersInMatch",
                newName: "TeamID");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "UsersInMatch",
                newName: "MatchID");

            migrationBuilder.RenameColumn(
                name: "UsersInMatchId",
                table: "UsersInMatch",
                newName: "UsersInMatchID");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInMatch_TeamId",
                table: "UsersInMatch",
                newName: "IX_UsersInMatch_TeamID");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInMatch_MatchId",
                table: "UsersInMatch",
                newName: "IX_UsersInMatch_MatchID");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "TeamsInTournament",
                newName: "TeamID");

            migrationBuilder.RenameColumn(
                name: "TeamsInTournamentId",
                table: "TeamsInTournament",
                newName: "TeamsInTournamentID");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInTournament_TeamId",
                table: "TeamsInTournament",
                newName: "IX_TeamsInTournament_TeamID");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "TeamsInMatch",
                newName: "TeamID");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "TeamsInMatch",
                newName: "MatchID");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInMatch_TeamId",
                table: "TeamsInMatch",
                newName: "IX_TeamsInMatch_TeamID");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInMatch_MatchId",
                table: "TeamsInMatch",
                newName: "IX_TeamsInMatch_MatchID");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Teams",
                newName: "TeamID");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Statistics",
                newName: "TeamID");

            migrationBuilder.RenameColumn(
                name: "StatisticsId",
                table: "Statistics",
                newName: "StatisticsID");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_TeamId",
                table: "Statistics",
                newName: "IX_Statistics_TeamID");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Matches",
                newName: "MatchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Teams_TeamID",
                table: "Statistics",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInMatch_Matches_MatchID",
                table: "TeamsInMatch",
                column: "MatchID",
                principalTable: "Matches",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInMatch_Teams_TeamID",
                table: "TeamsInMatch",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInTournament_Teams_TeamID",
                table: "TeamsInTournament",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInMatch_Matches_MatchID",
                table: "UsersInMatch",
                column: "MatchID",
                principalTable: "Matches",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInMatch_Teams_TeamID",
                table: "UsersInMatch",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
