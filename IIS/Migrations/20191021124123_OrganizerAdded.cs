using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class OrganizerAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizerUserID",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_OrganizerUserID",
                table: "Tournaments",
                column: "OrganizerUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Users_OrganizerUserID",
                table: "Tournaments",
                column: "OrganizerUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Users_OrganizerUserID",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_OrganizerUserID",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "OrganizerUserID",
                table: "Tournaments");
        }
    }
}
