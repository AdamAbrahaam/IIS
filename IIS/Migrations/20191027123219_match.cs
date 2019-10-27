using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class match : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMatch_Teams_TeamId",
                table: "UsersInMatch");

            migrationBuilder.DropIndex(
                name: "IX_UsersInMatch_TeamId",
                table: "UsersInMatch");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "UsersInMatch");

            migrationBuilder.DropColumn(
                name: "AwayTeam",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeam",
                table: "Matches");

            migrationBuilder.AddColumn<bool>(
                name: "Home",
                table: "UsersInMatch",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Home",
                table: "TeamsInMatch",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RefereeUserId",
                table: "Matches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RefereeUserId",
                table: "Matches",
                column: "RefereeUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_RefereeUserId",
                table: "Matches",
                column: "RefereeUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_RefereeUserId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_RefereeUserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Home",
                table: "UsersInMatch");

            migrationBuilder.DropColumn(
                name: "Home",
                table: "TeamsInMatch");

            migrationBuilder.DropColumn(
                name: "RefereeUserId",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "UsersInMatch",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AwayTeam",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeTeam",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                columns: new[] { "AwayTeam", "HomeTeam" },
                values: new object[] { "Imel", "Hurbanovo" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersInMatch_TeamId",
                table: "UsersInMatch",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInMatch_Teams_TeamId",
                table: "UsersInMatch",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
