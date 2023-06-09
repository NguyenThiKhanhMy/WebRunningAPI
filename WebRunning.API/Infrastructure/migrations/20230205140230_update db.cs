using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Infrastructure.migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdGiaoVien",
                table: "Por_KhoaHocs",
                newName: "IdLoaiKhoaHoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdLoaiKhoaHoc",
                table: "Por_KhoaHocs",
                newName: "IdGiaoVien");
        }
    }
}
