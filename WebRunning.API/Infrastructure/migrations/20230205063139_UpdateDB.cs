using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Infrastructure.migrations
{
    public partial class UpdateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThoiGianHoc",
                table: "Por_KhoaHocs");

            migrationBuilder.AddColumn<int>(
                name: "ThoiGianKhoaHoc",
                table: "Por_KhoaHocs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThoiGianKhoaHoc",
                table: "Por_KhoaHocs");

            migrationBuilder.AddColumn<string>(
                name: "ThoiGianHoc",
                table: "Por_KhoaHocs",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
