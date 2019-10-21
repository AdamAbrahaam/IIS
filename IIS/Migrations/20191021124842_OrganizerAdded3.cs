using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class OrganizerAdded3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Tournaments_TournamentID",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Users_UserID",
                table: "Statistics");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInTournament_Tournaments_TournamentID",
                table: "TeamsInTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Users_OrganizerUserID",
                table: "Tournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMatch_Users_UserID",
                table: "UsersInMatch");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UsersInMatch",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInMatch_UserID",
                table: "UsersInMatch",
                newName: "IX_UsersInMatch_UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "OrganizerUserID",
                table: "Tournaments",
                newName: "OrganizerUserId");

            migrationBuilder.RenameColumn(
                name: "TournamentID",
                table: "Tournaments",
                newName: "TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Tournaments_OrganizerUserID",
                table: "Tournaments",
                newName: "IX_Tournaments_OrganizerUserId");

            migrationBuilder.RenameColumn(
                name: "TournamentID",
                table: "TeamsInTournament",
                newName: "TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInTournament_TournamentID",
                table: "TeamsInTournament",
                newName: "IX_TeamsInTournament_TournamentId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Statistics",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_UserID",
                table: "Statistics",
                newName: "IX_Statistics_UserId");

            migrationBuilder.RenameColumn(
                name: "TournamentID",
                table: "Matches",
                newName: "TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_TournamentID",
                table: "Matches",
                newName: "IX_Matches_TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Tournaments_TournamentId",
                table: "Matches",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Users_UserId",
                table: "Statistics",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInTournament_Tournaments_TournamentId",
                table: "TeamsInTournament",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Users_OrganizerUserId",
                table: "Tournaments",
                column: "OrganizerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInMatch_Users_UserId",
                table: "UsersInMatch",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Tournaments_TournamentId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Users_UserId",
                table: "Statistics");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInTournament_Tournaments_TournamentId",
                table: "TeamsInTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Users_OrganizerUserId",
                table: "Tournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMatch_Users_UserId",
                table: "UsersInMatch");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UsersInMatch",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInMatch_UserId",
                table: "UsersInMatch",
                newName: "IX_UsersInMatch_UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "OrganizerUserId",
                table: "Tournaments",
                newName: "OrganizerUserID");

            migrationBuilder.RenameColumn(
                name: "TournamentId",
                table: "Tournaments",
                newName: "TournamentID");

            migrationBuilder.RenameIndex(
                name: "IX_Tournaments_OrganizerUserId",
                table: "Tournaments",
                newName: "IX_Tournaments_OrganizerUserID");

            migrationBuilder.RenameColumn(
                name: "TournamentId",
                table: "TeamsInTournament",
                newName: "TournamentID");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInTournament_TournamentId",
                table: "TeamsInTournament",
                newName: "IX_TeamsInTournament_TournamentID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Statistics",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics",
                newName: "IX_Statistics_UserID");

            migrationBuilder.RenameColumn(
                name: "TournamentId",
                table: "Matches",
                newName: "TournamentID");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_TournamentId",
                table: "Matches",
                newName: "IX_Matches_TournamentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Tournaments_TournamentID",
                table: "Matches",
                column: "TournamentID",
                principalTable: "Tournaments",
                principalColumn: "TournamentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Users_UserID",
                table: "Statistics",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInTournament_Tournaments_TournamentID",
                table: "TeamsInTournament",
                column: "TournamentID",
                principalTable: "Tournaments",
                principalColumn: "TournamentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Users_OrganizerUserID",
                table: "Tournaments",
                column: "OrganizerUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInMatch_Users_UserID",
                table: "UsersInMatch",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
