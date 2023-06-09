using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Infrastructure.migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdGiaoVien",
                table: "Por_KhoaHoc_GiaoAns",
                newName: "IdGiaoAn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdGiaoAn",
                table: "Por_KhoaHoc_GiaoAns",
                newName: "IdGiaoVien");
        }
    }
}
