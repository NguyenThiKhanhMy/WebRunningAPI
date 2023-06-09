using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Infrastructure.migrations
{
    public partial class updatekhoahoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoLuongNguoiHoc",
                table: "Por_KhoaHocs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TyLeDanhGia",
                table: "Por_KhoaHocs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLuongNguoiHoc",
                table: "Por_KhoaHocs");

            migrationBuilder.DropColumn(
                name: "TyLeDanhGia",
                table: "Por_KhoaHocs");
        }
    }
}
