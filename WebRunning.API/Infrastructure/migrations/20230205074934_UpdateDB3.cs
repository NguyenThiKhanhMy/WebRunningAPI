using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Infrastructure.migrations
{
    public partial class UpdateDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiaGiaoDong",
                table: "Por_MonHocs");

            migrationBuilder.AddColumn<double>(
                name: "GiaGiaoDongDen",
                table: "Por_MonHocs",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GiaGiaoDongTu",
                table: "Por_MonHocs",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiaGiaoDongDen",
                table: "Por_MonHocs");

            migrationBuilder.DropColumn(
                name: "GiaGiaoDongTu",
                table: "Por_MonHocs");

            migrationBuilder.AddColumn<string>(
                name: "GiaGiaoDong",
                table: "Por_MonHocs",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
