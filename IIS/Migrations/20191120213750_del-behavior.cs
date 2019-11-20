using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class delbehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Tournaments_TournamentId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Tournaments_TournamentId",
                table: "Statistics");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInMatches_Matches_MatchId",
                table: "TeamsInMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMatches_Matches_MatchId",
                table: "UsersInMatches");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Tournaments_TournamentId",
                table: "Matches",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Tournaments_TournamentId",
                table: "Statistics",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInMatches_Matches_MatchId",
                table: "TeamsInMatches",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInMatches_Matches_MatchId",
                table: "UsersInMatches",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Tournaments_TournamentId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Tournaments_TournamentId",
                table: "Statistics");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInMatches_Matches_MatchId",
                table: "TeamsInMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMatches_Matches_MatchId",
                table: "UsersInMatches");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Tournaments_TournamentId",
                table: "Matches",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Tournaments_TournamentId",
                table: "Statistics",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInMatches_Matches_MatchId",
                table: "TeamsInMatches",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInMatches_Matches_MatchId",
                table: "UsersInMatches",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
