using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebRunning.API.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Por_Anhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ma = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Ten = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    URL_Anh = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    IdNhomAnh = table.Column<Guid>(type: "uuid", nullable: false),
                    TrangThaiBanGhi = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_Anhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_ChiTietGioHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdKhoaHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    GiaTien = table.Column<double>(type: "double precision", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_ChiTietGioHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_GiaoVien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    URLAnhDaiDien = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Ma = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Ten = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    NgaySinh = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    GioiTinh = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ChungChi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ThanhTich = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_GiaoVien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_GioHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaiKhoan = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    HoVaTenNguoiMua = table.Column<string>(type: "text", nullable: true),
                    Sdt = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    SoLuongKhoaHoc = table.Column<int>(type: "integer", nullable: false),
                    TongThanhToan = table.Column<double>(type: "double precision", nullable: false),
                    XacNhanDonHang = table.Column<bool>(type: "boolean", nullable: false),
                    NgayThanhToan = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_GioHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_KhoaHocs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdMonHoc = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGiaoVien = table.Column<Guid>(type: "uuid", nullable: false),
                    TieuDe = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ThoiGianHoc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MoTa = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    NoiDung = table.Column<string>(type: "text", nullable: true),
                    URL_AnhDaiDien = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    GiaTien = table.Column<double>(type: "double precision", nullable: false),
                    HocPhiGoc = table.Column<double>(type: "double precision", nullable: false),
                    HocPhiGiamGia = table.Column<double>(type: "double precision", nullable: false),
                    TrangThai = table.Column<bool>(type: "boolean", nullable: false),
                    TrangThaiBanGhi = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_KhoaHocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ThuTu = table.Column<int>(type: "integer", nullable: false),
                    Ma = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Ten = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    URL = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    IdMenuCha = table.Column<Guid>(type: "uuid", nullable: false),
                    TrangThaiBanGhi = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_MonHocs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ma = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Ten = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    MoTa = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    URL_AnhDaiDien = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    GiaGiaoDong = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    IdMonHocCha = table.Column<Guid>(type: "uuid", nullable: false),
                    TrangThaiBanGhi = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_MonHocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_NhomAnhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ma = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Ten = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TrangThaiBanGhi = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_NhomAnhs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_NhomSuKiens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ma = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Ten = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    IdNhomSuKienCha = table.Column<Guid>(type: "uuid", nullable: false),
                    TrangThaiBanGhi = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_NhomSuKiens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_NhomTinTucs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ma = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Ten = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    IdNhomTinTucCha = table.Column<Guid>(type: "uuid", nullable: false),
                    TrangThaiBanGhi = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_NhomTinTucs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_SuKiens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ten = table.Column<string>(type: "character varying(155)", maxLength: 155, nullable: true),
                    DiaChi = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MoTa = table.Column<string>(type: "text", nullable: true),
                    NoiDung = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    GiaTien = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ThoiGian = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    URL_AnhDaiDien = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    TrangThai = table.Column<int>(type: "integer", nullable: false),
                    IdNhomSuKien = table.Column<Guid>(type: "uuid", nullable: false),
                    TrangThaiBanGhi = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_SuKiens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_ThongTinChuyenKhoans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenNganhang = table.Column<string>(type: "character varying(155)", maxLength: 155, nullable: true),
                    ChuThe = table.Column<string>(type: "character varying(155)", maxLength: 155, nullable: true),
                    SoTaiKhoan = table.Column<string>(type: "character varying(155)", maxLength: 155, nullable: true),
                    NoiDungChuyenKhoan = table.Column<string>(type: "character varying(155)", maxLength: 155, nullable: true),
                    URL_AnhQRCode = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_ThongTinChuyenKhoans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Por_TinTucs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TieuDe = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    MoTa = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    NoiDung = table.Column<string>(type: "text", nullable: true),
                    TacGia = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    URL_AnhDaiDien = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    NgayXuatBan = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    TinNoiBat = table.Column<bool>(type: "boolean", nullable: false),
                    TinMoi = table.Column<bool>(type: "boolean", nullable: false),
                    LuotXem = table.Column<int>(type: "integer", nullable: false),
                    IdNhomTinTuc = table.Column<Guid>(type: "uuid", nullable: false),
                    TrangThaiBanGhi = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Por_TinTucs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Authtokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    AccessToken = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    RefeshToken = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Authtokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Configs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Value = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Configs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Extension = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Path = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ObjectId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ObjectType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Content = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Receiver = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    DetailsURL = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ObjectId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ObjectType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Name = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsFunc = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Resources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Name = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Url = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Icon = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Name = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UserName = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    PassWord = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Email = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    TenantCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Users_Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrganId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Users_Roles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Por_Anhs");

            migrationBuilder.DropTable(
                name: "Por_ChiTietGioHangs");

            migrationBuilder.DropTable(
                name: "Por_GiaoVien");

            migrationBuilder.DropTable(
                name: "Por_GioHangs");

            migrationBuilder.DropTable(
                name: "Por_KhoaHocs");

            migrationBuilder.DropTable(
                name: "Por_Menus");

            migrationBuilder.DropTable(
                name: "Por_MonHocs");

            migrationBuilder.DropTable(
                name: "Por_NhomAnhs");

            migrationBuilder.DropTable(
                name: "Por_NhomSuKiens");

            migrationBuilder.DropTable(
                name: "Por_NhomTinTucs");

            migrationBuilder.DropTable(
                name: "Por_SuKiens");

            migrationBuilder.DropTable(
                name: "Por_ThongTinChuyenKhoans");

            migrationBuilder.DropTable(
                name: "Por_TinTucs");

            migrationBuilder.DropTable(
                name: "Sys_Authtokens");

            migrationBuilder.DropTable(
                name: "Sys_Categories");

            migrationBuilder.DropTable(
                name: "Sys_Configs");

            migrationBuilder.DropTable(
                name: "Sys_Files");

            migrationBuilder.DropTable(
                name: "Sys_Notification");

            migrationBuilder.DropTable(
                name: "Sys_Organizations");

            migrationBuilder.DropTable(
                name: "Sys_Permissions");

            migrationBuilder.DropTable(
                name: "Sys_Resources");

            migrationBuilder.DropTable(
                name: "Sys_Roles");

            migrationBuilder.DropTable(
                name: "Sys_Users");

            migrationBuilder.DropTable(
                name: "Sys_Users_Roles");
        }
    }
}
