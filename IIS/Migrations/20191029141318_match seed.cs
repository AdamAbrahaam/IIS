using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class matchseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInMatch_Matches_MatchId",
                table: "TeamsInMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInMatch_Teams_TeamId",
                table: "TeamsInMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMatch_Matches_MatchId",
                table: "UsersInMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMatch_Users_UserId",
                table: "UsersInMatch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInMatch",
                table: "UsersInMatch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamsInMatch",
                table: "TeamsInMatch");

            migrationBuilder.RenameTable(
                name: "UsersInMatch",
                newName: "UsersInMatches");

            migrationBuilder.RenameTable(
                name: "TeamsInMatch",
                newName: "TeamsInMatches");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInMatch_UserId",
                table: "UsersInMatches",
                newName: "IX_UsersInMatches_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInMatch_MatchId",
                table: "UsersInMatches",
                newName: "IX_UsersInMatches_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInMatch_TeamId",
                table: "TeamsInMatches",
                newName: "IX_TeamsInMatches_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInMatch_MatchId",
                table: "TeamsInMatches",
                newName: "IX_TeamsInMatches_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInMatches",
                table: "UsersInMatches",
                column: "UsersInMatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamsInMatches",
                table: "TeamsInMatches",
                column: "TeamsInMatchId");

            migrationBuilder.InsertData(
                table: "UsersInMatches",
                columns: new[] { "UsersInMatchId", "Home", "MatchId", "UserId" },
                values: new object[] { 1, true, 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInMatches_Matches_MatchId",
                table: "TeamsInMatches",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsInMatches_Teams_TeamId",
                table: "TeamsInMatches",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInMatches_Matches_MatchId",
                table: "UsersInMatches",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInMatches_Users_UserId",
                table: "UsersInMatches",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInMatches_Matches_MatchId",
                table: "TeamsInMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsInMatches_Teams_TeamId",
                table: "TeamsInMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMatches_Matches_MatchId",
                table: "UsersInMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInMatches_Users_UserId",
                table: "UsersInMatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInMatches",
                table: "UsersInMatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamsInMatches",
                table: "TeamsInMatches");

            migrationBuilder.DeleteData(
                table: "UsersInMatches",
                keyColumn: "UsersInMatchId",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "UsersInMatches",
                newName: "UsersInMatch");

            migrationBuilder.RenameTable(
                name: "TeamsInMatches",
                newName: "TeamsInMatch");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInMatches_UserId",
                table: "UsersInMatch",
                newName: "IX_UsersInMatch_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInMatches_MatchId",
                table: "UsersInMatch",
                newName: "IX_UsersInMatch_MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInMatches_TeamId",
                table: "TeamsInMatch",
                newName: "IX_TeamsInMatch_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsInMatches_MatchId",
                table: "TeamsInMatch",
                newName: "IX_TeamsInMatch_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInMatch",
                table: "UsersInMatch",
                column: "UsersInMatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamsInMatch",
                table: "TeamsInMatch",
                column: "TeamsInMatchId");

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
                name: "FK_UsersInMatch_Matches_MatchId",
                table: "UsersInMatch",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInMatch_Users_UserId",
                table: "UsersInMatch",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
