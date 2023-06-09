using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Infrastructure.migrations
{
    public partial class UpdateDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThoiGianTruyCapMienPhi",
                table: "Por_KhoaHocs",
                newName: "ThoiHanTruyCapMienPhi");

            migrationBuilder.RenameColumn(
                name: "ThoiGianKhoaHoc",
                table: "Por_KhoaHocs",
                newName: "ThoiHan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThoiHanTruyCapMienPhi",
                table: "Por_KhoaHocs",
                newName: "ThoiGianTruyCapMienPhi");

            migrationBuilder.RenameColumn(
                name: "ThoiHan",
                table: "Por_KhoaHocs",
                newName: "ThoiGianKhoaHoc");
        }
    }
}
