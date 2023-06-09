using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using WebRunning.Lib.Models;

namespace WebRunning.API.Model
{
    [Table("Por_ThongTinChuyenKhoans")]
    public class Por_ThongTinChuyenKhoan : AuditEntity
    {
        [StringLength(155)]
        public string TenNganhang { get; set; }
        [StringLength(155)]
        public string ChuThe { get; set; }
        [StringLength(155)]
        public string SoTaiKhoan { get; set; }
        [StringLength(155)]
        public string NoiDungChuyenKhoan { get; set; }
        [StringLength(500)]
        public string URL_AnhQRCode { get; set; }
    }
}
