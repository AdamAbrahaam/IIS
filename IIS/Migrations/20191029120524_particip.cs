using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class particip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInTournament_Teams_TeamId",
                table: "TeamsInTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInTournament_Tournaments_TournamentId",
                table: "TeamsInTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInTournament_Tournaments_TournamentId",
                table: "UsersInTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInTournament_Users_UserId",
                table: "UsersInTournament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInTournament",
                table: "UsersInTournament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamsInTournament",
                table: "TeamsInTournament");

            migrationBuilder.RenameTable(
                name: "UsersInTournament",
                newName: "UsersInTournaments");

            migrationBuilder.RenameTable(
                name: "TeamsInTournament",
                newName: "TeamsInTournaments");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInTournament_UserId",
                table: "UsersInTournaments",
                newName: "IX_UsersInTournaments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInTournament_TournamentId",
                table: "UsersInTournaments",
                newName: "IX_UsersInTournaments_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInTournament_TournamentId",
                table: "TeamsInTournaments",
                newName: "IX_TeamsInTournaments_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInTournament_TeamId",
                table: "TeamsInTournaments",
                newName: "IX_TeamsInTournaments_TeamId");

            migrationBuilder.AddColumn<string>(
                name: "Participants",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefereeUserId",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInTournaments",
                table: "UsersInTournaments",
                column: "UsersInTournamentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamsInTournaments",
                table: "TeamsInTournaments",
                column: "TeamsInTournamentId");

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                column: "Sponsors",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2,
                column: "Sponsors",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3,
                column: "Sponsors",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 4,
                column: "Sponsors",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 5,
                column: "Sponsors",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_RefereeUserId",
                table: "Tournaments",
                column: "RefereeUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInTournaments_Teams_TeamId",
                table: "TeamsInTournaments",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInTournaments_Tournaments_TournamentId",
                table: "TeamsInTournaments",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Users_RefereeUserId",
                table: "Tournaments",
                column: "RefereeUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInTournaments_Tournaments_TournamentId",
                table: "UsersInTournaments",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInTournaments_Users_UserId",
                table: "UsersInTournaments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInTournaments_Teams_TeamId",
                table: "TeamsInTournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInTournaments_Tournaments_TournamentId",
                table: "TeamsInTournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Users_RefereeUserId",
                table: "Tournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInTournaments_Tournaments_TournamentId",
                table: "UsersInTournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInTournaments_Users_UserId",
                table: "UsersInTournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_RefereeUserId",
                table: "Tournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInTournaments",
                table: "UsersInTournaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamsInTournaments",
                table: "TeamsInTournaments");

            migrationBuilder.DropColumn(
                name: "Participants",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "RefereeUserId",
                table: "Tournaments");

            migrationBuilder.RenameTable(
                name: "UsersInTournaments",
                newName: "UsersInTournament");

            migrationBuilder.RenameTable(
                name: "TeamsInTournaments",
                newName: "TeamsInTournament");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInTournaments_UserId",
                table: "UsersInTournament",
                newName: "IX_UsersInTournament_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInTournaments_TournamentId",
                table: "UsersInTournament",
                newName: "IX_UsersInTournament_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInTournaments_TournamentId",
                table: "TeamsInTournament",
                newName: "IX_TeamsInTournament_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInTournaments_TeamId",
                table: "TeamsInTournament",
                newName: "IX_TeamsInTournament_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInTournament",
                table: "UsersInTournament",
                column: "UsersInTournamentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamsInTournament",
                table: "TeamsInTournament",
                column: "TeamsInTournamentId");

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                column: "Sponsors",
                value: "asd,dsa");

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2,
                column: "Sponsors",
                value: "asd,dsa");

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3,
                column: "Sponsors",
                value: "asd,dsa");

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 4,
                column: "Sponsors",
                value: "asd,dsa");

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 5,
                column: "Sponsors",
                value: "asd,dsa");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInTournament_Teams_TeamId",
                table: "TeamsInTournament",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInTournament_Tournaments_TournamentId",
                table: "TeamsInTournament",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInTournament_Tournaments_TournamentId",
                table: "UsersInTournament",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInTournament_Users_UserId",
                table: "UsersInTournament",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
