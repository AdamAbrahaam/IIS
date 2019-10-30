using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class tournamentDetailEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Users_OrganizerUserId",
                table: "Tournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Users_RefereeUserId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_OrganizerUserId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_RefereeUserId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "OrganizerUserId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "RefereeUserId",
                table: "Tournaments");

            migrationBuilder.AddColumn<string>(
                name: "Organizer",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Referee",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                column: "Organizer",
                value: "Daniel Weis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Organizer",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "Referee",
                table: "Tournaments");

            migrationBuilder.AddColumn<int>(
                name: "OrganizerUserId",
                table: "Tournaments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefereeUserId",
                table: "Tournaments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                column: "OrganizerUserId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_OrganizerUserId",
                table: "Tournaments",
                column: "OrganizerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_RefereeUserId",
                table: "Tournaments",
                column: "RefereeUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Users_OrganizerUserId",
                table: "Tournaments",
                column: "OrganizerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Users_RefereeUserId",
                table: "Tournaments",
                column: "RefereeUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
