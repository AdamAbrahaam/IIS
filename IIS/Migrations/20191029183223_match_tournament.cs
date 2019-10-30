using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class match_tournament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AwayTeam",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeTeam",
                table: "Matches",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                columns: new[] { "AwayTeam", "HomeTeam" },
                values: new object[] { "Imel", "Hurbanovo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayTeam",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HomeTeam",
                table: "Matches");
        }
    }
}
