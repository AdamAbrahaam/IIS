using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class NewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentID",
                keyValue: 1,
                column: "Location",
                value: "Bozetechova");

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "TournamentID", "Capacity", "Date", "Entry", "Location", "Name", "Prize", "Type" },
                values: new object[,]
                {
                    { 2, 802, new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6002, "Bozetechova2", "FIT - BIT2", 5002, 1 },
                    { 3, 803, new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6003, "Bozetechova3", "FIT - BIT3", 5003, 0 },
                    { 4, 804, new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 604, "Bozetechova4", "FIT - BIT4", 504, 1 },
                    { 5, 805, new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 605, "Bozetechova5", "FIT - BIT5", 505, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "TournamentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "TournamentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "TournamentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tournaments",
                keyColumn: "TournamentID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentID",
                keyValue: 1,
                column: "Location",
                value: null);
        }
    }
}
