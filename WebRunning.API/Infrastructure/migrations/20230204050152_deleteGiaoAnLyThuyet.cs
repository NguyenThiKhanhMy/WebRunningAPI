using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Infrastructure.migrations
{
    public partial class deleteGiaoAnLyThuyet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Por_GiaoAnLyThuyets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Por_GiaoAnLyThuyets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IdGiaoAnLyThuyet = table.Column<Guid>(type: "uuid", nullable: false),
                    Loai = table.Column<int>(type: "integer", nullable: false),
                    MienPhi = table.Column<bool>(type: "boolean", nullable: false),
                    SoThuTu = table.Column<int>(type: "integer", nullable: false),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    ThoiLuong = table.Column<double>(type: "double precision", nullable: false),
                    TieuDe = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    URL_Video = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_GiaoAnLyThuyets", x => x.Id);
                });
        }
    }
}
