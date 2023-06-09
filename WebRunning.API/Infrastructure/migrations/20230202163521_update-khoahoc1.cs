using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Infrastructure.migrations
{
    public partial class updatekhoahoc1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThaiBanGhi",
                table: "Por_NhomAnhs");

            migrationBuilder.DropColumn(
                name: "GiaTien",
                table: "Por_KhoaHocs");

            migrationBuilder.DropColumn(
                name: "TrangThaiBanGhi",
                table: "Por_Anhs");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "Por_KhoaHocs",
                newName: "URL_VideoDaiDien");

            migrationBuilder.AddColumn<string>(
                name: "GioiThieu",
                table: "Por_KhoaHocs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThoiGianTruyCapQC",
                table: "Por_KhoaHocs",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Por_GiaoAnLyThuyets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGiaoAnLyThuyet = table.Column<Guid>(type: "uuid", nullable: false),
                    TieuDe = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    URL_Video = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    SoThuTu = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_GiaoAnLyThuyets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_GiaoAnThucHanhChiTiets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGiaoAnThucHanh = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGiaoAnThucHanhChiTiet = table.Column<Guid>(type: "uuid", nullable: false),
                    TieuDe = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    ChiTiet = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    URL_Video = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    SoThuTu = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_GiaoAnThucHanhChiTiets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_GiaoAnThucHanhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ma = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    TieuDe = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    MoTa = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    SoThuTu = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_GiaoAnThucHanhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_KhoaHoc_GiaoAns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKhoaHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGiaoVien = table.Column<Guid>(type: "uuid", nullable: false),
                    LoaiGiaoAnLy = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_KhoaHoc_GiaoAns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_NhomVideos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ma = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Ten = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_NhomVideos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_Videos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ma = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Ten = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    URL_Video = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ThoiLuong = table.Column<string>(type: "text", nullable: true),
                    IdNhomVideo = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_Videos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Por_GiaoAnLyThuyets");

            migrationBuilder.DropTable(
                name: "Por_GiaoAnThucHanhChiTiets");

            migrationBuilder.DropTable(
                name: "Por_GiaoAnThucHanhs");

            migrationBuilder.DropTable(
                name: "Por_KhoaHoc_GiaoAns");

            migrationBuilder.DropTable(
                name: "Por_NhomVideos");

            migrationBuilder.DropTable(
                name: "Por_Videos");

            migrationBuilder.DropColumn(
                name: "GioiThieu",
                table: "Por_KhoaHocs");

            migrationBuilder.DropColumn(
                name: "ThoiGianTruyCapQC",
                table: "Por_KhoaHocs");

            migrationBuilder.RenameColumn(
                name: "URL_VideoDaiDien",
                table: "Por_KhoaHocs",
                newName: "MoTa");

            migrationBuilder.AddColumn<bool>(
                name: "TrangThaiBanGhi",
                table: "Por_NhomAnhs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "GiaTien",
                table: "Por_KhoaHocs",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "TrangThaiBanGhi",
                table: "Por_Anhs",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
