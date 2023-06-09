using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebRunning.Lib.Models;

namespace WebRunning.API.Model
{
    [Table("Por_KhoaHocs")]
    public class Por_KhoaHoc : AuditEntity
    {
        public Guid IdMonHoc { get; set; }
        public Guid IdLoaiKhoaHoc { get; set; }

        [StringLength(200)]
        public string TieuDe { get; set; }
        public int ThoiHan { get; set; }
        public int ThoiHanTruyCapMienPhi { get; set; }
        [MaxLength]
        public string GioiThieu { get; set; }
        [MaxLength]
        public string NoiDung { get; set; }
        [StringLength(500)]
        public string URL_AnhDaiDien { get; set; }
        [StringLength(500)]
        public string URL_AnhChiTiet { get; set; }
        [StringLength(500)]
        public string URL_VideoDaiDien { get; set; }
        public double HocPhiGoc { get; set; }
        public double HocPhiGiamGia { get; set; }
        public bool TrangThai { get; set; }
        public bool TrangThaiBanGhi { get; set; }
        public int TyLeDanhGia { get; set; }
        public int SoLuongNguoiHoc { get; set; }
    }
}
