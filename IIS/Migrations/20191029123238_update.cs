using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_RefereeUserId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "TeamsInTournaments");

            migrationBuilder.DropTable(
                name: "UsersInTournaments");

            migrationBuilder.DropIndex(
                name: "IX_Matches_RefereeUserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "RefereeUserId",
                table: "Matches");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Tournaments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Tournaments",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Tournaments",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Matches",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Matches",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "Date",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                columns: new[] { "Date", "Type" },
                values: new object[] { null, "duo" });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2,
                columns: new[] { "Date", "Type" },
                values: new object[] { null, "duo" });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3,
                columns: new[] { "Date", "Type" },
                values: new object[] { null, "solo" });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 4,
                columns: new[] { "Date", "Type" },
                values: new object[] { null, "duo" });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 5,
                columns: new[] { "Date", "Type" },
                values: new object[] { null, "solo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Tournaments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Tournaments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Matches",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefereeUserId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamsInTournaments",
                columns: table => new
                {
                    TeamsInTournamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    TournamentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsInTournaments", x => x.TeamsInTournamentId);
                    table.ForeignKey(
                        name: "FK_TeamsInTournaments_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamsInTournaments_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersInTournaments",
                columns: table => new
                {
                    UsersInTournamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInTournaments", x => x.UsersInTournamentId);
                    table.ForeignKey(
                        name: "FK_UsersInTournaments_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersInTournaments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Matches",
                keyColumn: "MatchId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 1,
                columns: new[] { "Date", "Type" },
                values: new object[] { new DateTime(2019, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 2,
                columns: new[] { "Date", "Type" },
                values: new object[] { new DateTime(2019, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 3,
                columns: new[] { "Date", "Type" },
                values: new object[] { new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 4,
                columns: new[] { "Date", "Type" },
                values: new object[] { new DateTime(2019, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Tournaments",
                keyColumn: "TournamentId",
                keyValue: 5,
                columns: new[] { "Date", "Type" },
                values: new object[] { new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RefereeUserId",
                table: "Matches",
                column: "RefereeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInTournaments_TeamId",
                table: "TeamsInTournaments",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamsInTournaments_TournamentId",
                table: "TeamsInTournaments",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInTournaments_TournamentId",
                table: "UsersInTournaments",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInTournaments_UserId",
                table: "UsersInTournaments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_RefereeUserId",
                table: "Matches",
                column: "RefereeUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
