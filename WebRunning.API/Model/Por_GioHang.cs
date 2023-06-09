using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using WebRunning.Lib.Models;

namespace WebRunning.API.Model
{
    [Table("Por_GioHangs")]
    public class Por_GioHang : AuditEntity
    {
        [StringLength(55)]
        public string TaiKhoan { get; set; }
        public string HoVaTenNguoiMua { get; set; }
        [StringLength(150)]
        public string Sdt { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        public int SoLuongKhoaHoc { get; set; }
        public double TongThanhToan { get; set; }
        public bool XacNhanDonHang { get; set; }
        public DateTimeOffset NgayThanhToan { get; set; }

    }
}
