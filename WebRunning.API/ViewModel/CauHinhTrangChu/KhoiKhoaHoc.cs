using System;
using System.ComponentModel.DataAnnotations;

namespace WebRunning.API.ViewModel.CauHinhTrangChu
{
    public class KhoiKhoaHoc
    {
        public Guid Id { get; set; }
        public string TieuDe { get; set; }
        public string URL_AnhDaiDien { get; set; }
        public double ThoiHan { get; set; }
        public double ThoiHanTruyCapMienPhi { get; set; }
        public int TyLeDanhGia {get;set;}
        public int SoLuongNguoiHoc { get; set; }
        public double HocPhiGoc { get; set; }
        public double HocPhiGiamGia { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string TenMonHoc { get; set; }
    }
}
