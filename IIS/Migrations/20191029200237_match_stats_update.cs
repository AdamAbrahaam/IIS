using Microsoft.EntityFrameworkCore.Migrations;

namespace IIS.Migrations
{
    public partial class match_stats_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "Statistics",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Team",
                table: "Statistics");
        }
    }
}
