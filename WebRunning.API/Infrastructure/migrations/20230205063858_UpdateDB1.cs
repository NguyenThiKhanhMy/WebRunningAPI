using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Infrastructure.migrations
{
    public partial class UpdateDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThoiGianTruyCapQC",
                table: "Por_KhoaHocs");

            migrationBuilder.AddColumn<int>(
                name: "ThoiGianTruyCapMienPhi",
                table: "Por_KhoaHocs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThoiGianTruyCapMienPhi",
                table: "Por_KhoaHocs");

            migrationBuilder.AddColumn<string>(
                name: "ThoiGianTruyCapQC",
                table: "Por_KhoaHocs",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
