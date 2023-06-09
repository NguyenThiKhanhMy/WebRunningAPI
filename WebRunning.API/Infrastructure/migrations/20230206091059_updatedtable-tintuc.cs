using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Infrastructure.migrations
{
    public partial class updatedtabletintuc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TinMoi",
                table: "Por_TinTucs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TinMoi",
                table: "Por_TinTucs",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
