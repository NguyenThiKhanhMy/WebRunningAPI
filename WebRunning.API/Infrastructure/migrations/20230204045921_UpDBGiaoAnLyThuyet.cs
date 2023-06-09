using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Infrastructure.migrations
{
    public partial class UpDBGiaoAnLyThuyet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThoiLuong",
                table: "Por_Videos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ThoiLuong",
                table: "Por_Videos",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
