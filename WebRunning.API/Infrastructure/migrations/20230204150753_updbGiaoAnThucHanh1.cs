using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Infrastructure.migrations
{
    public partial class updbGiaoAnThucHanh1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdGiaoAnLyThuyet",
                table: "Por_GiaoAnThucHanhs",
                newName: "IdGiaoAnThucHanh");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdGiaoAnThucHanh",
                table: "Por_GiaoAnThucHanhs",
                newName: "IdGiaoAnLyThuyet");
        }
    }
}
