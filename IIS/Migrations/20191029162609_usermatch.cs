using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class usermatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AwayUserId",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeUserId",
                table: "Matches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayUserId",
                table: "Matches",
                column: "AwayUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeUserId",
                table: "Matches",
                column: "HomeUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_AwayUserId",
                table: "Matches",
                column: "AwayUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_HomeUserId",
                table: "Matches",
                column: "HomeUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_AwayUserId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_HomeUserId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_AwayUserId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_HomeUserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "AwayUserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeUserId",
                table: "Matches");
        }
    }
}
