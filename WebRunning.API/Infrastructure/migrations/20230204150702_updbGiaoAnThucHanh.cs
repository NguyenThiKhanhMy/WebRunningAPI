using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Infrastructure.migrations
{
    public partial class updbGiaoAnThucHanh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Por_GiaoAnThucHanhChiTiets");

            migrationBuilder.DropColumn(
                name: "Ma",
                table: "Por_GiaoAnThucHanhs");

            migrationBuilder.DropColumn(
                name: "MoTa",
                table: "Por_GiaoAnThucHanhs");

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "Por_GiaoAnThucHanhs",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdGiaoAnLyThuyet",
                table: "Por_GiaoAnThucHanhs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Loai",
                table: "Por_GiaoAnThucHanhs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "MienPhi",
                table: "Por_GiaoAnThucHanhs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "ThoiLuong",
                table: "Por_GiaoAnThucHanhs",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "URL_Video",
                table: "Por_GiaoAnThucHanhs",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "Por_GiaoAnThucHanhs");

            migrationBuilder.DropColumn(
                name: "IdGiaoAnLyThuyet",
                table: "Por_GiaoAnThucHanhs");

            migrationBuilder.DropColumn(
                name: "Loai",
                table: "Por_GiaoAnThucHanhs");

            migrationBuilder.DropColumn(
                name: "MienPhi",
                table: "Por_GiaoAnThucHanhs");

            migrationBuilder.DropColumn(
                name: "ThoiLuong",
                table: "Por_GiaoAnThucHanhs");

            migrationBuilder.DropColumn(
                name: "URL_Video",
                table: "Por_GiaoAnThucHanhs");

            migrationBuilder.AddColumn<string>(
                name: "Ma",
                table: "Por_GiaoAnThucHanhs",
                type: "character varying(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoTa",
                table: "Por_GiaoAnThucHanhs",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Por_GiaoAnThucHanhChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChiTiet = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IdGiaoAnThucHanh = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGiaoAnThucHanhChiTiet = table.Column<Guid>(type: "uuid", nullable: false),
                    SoThuTu = table.Column<int>(type: "integer", nullable: false),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    TieuDe = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    URL_Video = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_GiaoAnThucHanhChiTiets", x => x.Id);
                });
        }
    }
}
