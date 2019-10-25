using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class tournamentedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sponsors",
                table: "Tournaments",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sponsors",
                table: "Tournaments");
        }
    }
}
