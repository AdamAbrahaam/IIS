using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class tournamentSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                columns: new[] { "Capacity", "Date", "Entry", "Sponsors", "Time", "Type" },
                values: new object[] { 16, "22-10-2020", 5, "Coca Cola", "14:00", "Duo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                columns: new[] { "Capacity", "Date", "Entry", "Sponsors", "Time", "Type" },
                values: new object[] { 800, null, 600, null, null, "duo" });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "TournamentId", "Capacity", "Date", "Entry", "Info", "Location", "Name", "Organizer", "Participants", "Prize", "Referee", "Sponsors", "Time", "Type" },
                values: new object[,]
                {
                    { 2, 802, null, 6002, null, "Bozetechova2", "FIT - BIT2", null, null, 5002, null, null, null, "duo" },
                    { 3, 803, null, 6003, null, "Bozetechova3", "FIT - BIT3", null, null, 5003, null, null, null, "solo" },
                    { 4, 804, null, 604, null, "Bozetechova4", "FIT - BIT4", null, null, 504, null, null, null, "duo" },
                    { 5, 805, null, 605, null, "Bozetechova5", "FIT - BIT5", null, null, 505, null, null, null, "solo" }
                });
        }
    }
}
