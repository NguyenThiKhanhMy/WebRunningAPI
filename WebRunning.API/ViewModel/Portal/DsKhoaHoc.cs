using System;
using WebRunning.Lib.Models;

namespace WebRunning.API.ViewModel.Portal
{
    public class DsKhoaHoc 
    {
        public Guid Id { get; set; }
        public string TenMonHoc { get; set; }
        public string TenLoaiKhoaHoc { get; set; }
        public string TieuDe { get; set; }
        public int ThoiHan { get; set; }
        public int ThoiHanTruyCapMienPhi { get; set; }
        public string GiaTien { get; set; }
        public string GioiThieu { get; set; }
        public string NoiDung { get; set; }
        public string URL_AnhDaiDien { get; set; }
        public double HocPhiGoc { get; set; }
        public double HocPhiGiamGia { get; set; }
        public bool TrangThai { get; set; }
        public bool TrangThaiBanGhi { get; set; }
        public int TyLeDanhGia { get; set; }
        public int SoLuongNguoiHoc { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public Guid IdMonHoc { get; set; }
    }
}