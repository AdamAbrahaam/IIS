using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class usersintournament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersInTournament",
                columns: table => new
                {
                    UsersInTournamentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInTournament", x => x.UsersInTournamentId);
                    table.ForeignKey(
                        name: "FK_UsersInTournament_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersInTournament_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersInTournament_TournamentId",
                table: "UsersInTournament",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInTournament_UserId",
                table: "UsersInTournament",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersInTournament");
        }
    }
}
