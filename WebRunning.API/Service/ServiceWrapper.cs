using Microsoft.Extensions.Configuration;
using WebRunning.API.Infrastructure;
using WebRunning.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.API.Model;

namespace WebRunning.API.Service
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly DomainDbContext _context;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IUserProvider _userProvider;
        private Sys_AuthToken.IService _sys_authtoken;
        private Sys_Category.IService _sys_category;
        private Sys_User.IService _sys_user;
        private Sys_Role.IService _sys_role;
        private Sys_Config.IService _sys_config;
        private Sys_Resource.IService _sys_resource;
        private Sys_Organization.IService _sys_organization;
        private Sys_Permission.IService _sys_permission;
        private Sys_File.IService _sys_file;
        private Sys_Notification.IService _sys_notification;
        private Por_Anh.IService _por_anh;
        private Por_ChiTietGioHang.IService _por_chitietgiohang;
        private Por_DangKyTuVan.IService _por_dangkytuvan;
        private Por_GiaoVien.IService _por_giaovien;
        private Por_GioHang.IService _por_giohang;
        private Por_KhoaHoc.IService _por_khoahoc;
        private Por_Menu.IService _por_menu;
        private Por_MonHoc.IService _por_monhoc;
        private Por_NhomAnh.IService _por_nhomanh;
        private Por_NhomSuKien.IService _por_nhomsukien;
        private Por_NhomTinTuc.IService _por_nhomtintuc;
        private Por_SuKien.IService _por_sukien;
        private Por_ThongTinChuyenKhoan.IService _por_thongtinchuyenkhoan;
        private Por_TinTuc.IService _por_tintuc;
        private Por_LoaiKhoaHoc.IService _por_loaikhoahoc;
        private Por_CauHinhGiaoDien.IService _por_cauhinhgiaodien;
        private Por_Video.IService _por_video;
        private Por_NhomVideo.IService _por_nhomvideo;
        private Por_KhoaHoc_GiaoAn.IService _por_khoahoc_giaoan;
        private Por_GiaoAnLyThuyet.IService _por_giaoanlythuyet;
        private Por_GiaoAnThucHanh.IService _por_giaoanthuchanh;
        public ServiceWrapper(DomainDbContext context, IDateTimeProvider dateTimeProvider, IUserProvider userService, IConfiguration configuration)
        {
            _context = context;
            _dateTimeProvider = dateTimeProvider;
            _userProvider = userService;
        }

        /*Start Portal*/
        public Por_KhoaHoc_GiaoAn.IService Por_KhoaHoc_GiaoAn
        {
            get
            {
                if (_por_khoahoc_giaoan == null)
                {
                    _por_khoahoc_giaoan = new Por_KhoaHoc_GiaoAn.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_khoahoc_giaoan;
            }
        }
        public Por_GiaoAnLyThuyet.IService Por_GiaoAnLyThuyet
        {
            get
            {
                if (_por_giaoanlythuyet == null)
                {
                    _por_giaoanlythuyet = new Por_GiaoAnLyThuyet.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_giaoanlythuyet;
            }
        }
        public Por_GiaoAnThucHanh.IService Por_GiaoAnThucHanh
        {
            get
            {
                if (_por_giaoanthuchanh == null)
                {
                    _por_giaoanthuchanh = new Por_GiaoAnThucHanh.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_giaoanthuchanh;
            }
        }
        public Por_NhomVideo.IService Por_NhomVideo
        {
            get
            {
                if (_por_nhomvideo == null)
                {
                    _por_nhomvideo = new Por_NhomVideo.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_nhomvideo;
            }
        }
        public Por_Video.IService Por_Video
        {
            get
            {
                if (_por_video == null)
                {
                    _por_video = new Por_Video.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_video;
            }
        }
        public Por_CauHinhGiaoDien.IService Por_CauHinhGiaoDien
        {
            get
            {
                if (_por_cauhinhgiaodien == null)
                {
                    _por_cauhinhgiaodien = new Por_CauHinhGiaoDien.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_cauhinhgiaodien;
            }
        }
        public Por_LoaiKhoaHoc.IService Por_LoaiKhoaHoc
        {
            get
            {
                if (_por_loaikhoahoc == null)
                {
                    _por_loaikhoahoc = new Por_LoaiKhoaHoc.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_loaikhoahoc;
            }
        }
        public Por_Anh.IService Por_Anh
        {
            get
            {
                if (_por_anh == null)
                {
                    _por_anh = new Por_Anh.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_anh;
            }
        }
        public Por_ChiTietGioHang.IService Por_ChiTietGioHang
        {
            get
            {
                if (_por_chitietgiohang == null)
                {
                    _por_chitietgiohang = new Por_ChiTietGioHang.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_chitietgiohang;
            }
        }

        public Por_DangKyTuVan.IService Por_DangKyTuVan
        {
            get
            {
                if (_por_dangkytuvan == null)
                {
                    _por_dangkytuvan = new Por_DangKyTuVan.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_dangkytuvan;
            }
        }

        public Por_GiaoVien.IService Por_GiaoVien
        {
            get
            {
                if (_por_giaovien == null)
                {
                    _por_giaovien = new Por_GiaoVien.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_giaovien;
            }
        }
        public Por_GioHang.IService Por_GioHang
        {
            get
            {
                if (_por_giohang == null)
                {
                    _por_giohang = new Por_GioHang.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_giohang;
            }
        }
        public Por_KhoaHoc.IService Por_KhoaHoc
        {
            get
            {
                if (_por_khoahoc == null)
                {
                    _por_khoahoc = new Por_KhoaHoc.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_khoahoc;
            }
        }
        public Por_Menu.IService Por_Menu
        {
            get
            {
                if (_por_menu == null)
                {
                    _por_menu = new Por_Menu.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_menu;
            }
        }
        public Por_MonHoc.IService Por_MonHoc
        {
            get
            {
                if (_por_monhoc == null)
                {
                    _por_monhoc = new Por_MonHoc.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_monhoc;
            }
        }
        public Por_NhomAnh.IService Por_NhomAnh
        {
            get
            {
                if (_por_nhomanh == null)
                {
                    _por_nhomanh = new Por_NhomAnh.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_nhomanh;
            }
        }
        public Por_NhomSuKien.IService Por_NhomSuKien
        {
            get
            {
                if (_por_nhomsukien == null)
                {
                    _por_nhomsukien = new Por_NhomSuKien.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_nhomsukien;
            }
        }
        public Por_NhomTinTuc.IService Por_NhomTinTuc
        {
            get
            {
                if (_por_nhomtintuc == null)
                {
                    _por_nhomtintuc = new Por_NhomTinTuc.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_nhomtintuc;
            }
        }
        public Por_SuKien.IService Por_SuKien
        {
            get
            {
                if (_por_sukien == null)
                {
                    _por_sukien = new Por_SuKien.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_sukien;
            }
        }

        public Por_ThongTinChuyenKhoan.IService Por_ThongTinChuyenKhoan
        {
            get
            {
                if (_por_thongtinchuyenkhoan == null)
                {
                    _por_thongtinchuyenkhoan = new Por_ThongTinChuyenKhoan.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_thongtinchuyenkhoan;
            }
        }
        public Por_TinTuc.IService Por_TinTuc
        {
            get
            {
                if (_por_tintuc == null)
                {
                    _por_tintuc = new Por_TinTuc.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _por_tintuc;
            }
        }
        /*End Portal*/
        public Sys_Notification.IService Sys_Notification
        {
            get
            {
                if (_sys_notification == null)
                {
                    _sys_notification = new Sys_Notification.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _sys_notification;
            }
        }
        public Sys_AuthToken.IService Sys_AuthToken
        {
            get
            {
                if (_sys_authtoken == null)
                {
                    _sys_authtoken = new Sys_AuthToken.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _sys_authtoken;
            }
        }
        public Sys_File.IService Sys_File
        {
            get
            {
                if (_sys_file == null)
                {
                    _sys_file = new Sys_File.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _sys_file;
            }
        }
        public Sys_Category.IService Sys_Category
        {
            get
            {
                if (_sys_category == null)
                {
                    _sys_category = new Sys_Category.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _sys_category;
            }
        }
        public Sys_User.IService Sys_User
        {
            get
            {
                if (_sys_user == null)
                {
                    _sys_user = new Sys_User.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _sys_user;
            }
        }
        public Sys_Organization.IService Sys_Organization
        {
            get
            {
                if (_sys_organization == null)
                {
                    _sys_organization = new Sys_Organization.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _sys_organization;
            }
        }
        public Sys_Role.IService Sys_Role
        {
            get
            {
                if (_sys_role == null)
                {
                    _sys_role = new Sys_Role.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _sys_role;
            }
        }
        public Sys_Config.IService Sys_Config
        {
            get
            {
                if (_sys_config == null)
                {
                    _sys_config = new Sys_Config.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _sys_config;
            }
        }
        public Sys_Resource.IService Sys_Resource
        {
            get
            {
                if (_sys_resource == null)
                {
                    _sys_resource = new Sys_Resource.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _sys_resource;
            }
        }
        public Sys_Permission.IService Sys_Permission
        {
            get
            {
                if (_sys_permission == null)
                {
                    _sys_permission = new Sys_Permission.Service(_context, _dateTimeProvider, _userProvider);
                }

                return _sys_permission;
            }
        }

    }
}
