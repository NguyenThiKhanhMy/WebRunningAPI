using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebRunning.Lib.Models;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.Model
{
    [Table("Por_GiaoAnThucHanhs")]
    public class Por_GiaoAnThucHanh : AuditEntity
    {
        public Guid IdGiaoAnThucHanh { get; set; }
        public LoaiGiaoAnThucHanh Loai { get; set; }
        [StringLength(250)]
        public string TieuDe { get; set; }
        [StringLength(500)]
        public string GhiChu { get; set; }

        [StringLength(500)]
        public string URL_Video { get; set; }
        public double ThoiLuong { get; set; }
        public bool MienPhi { get; set; }
        public int SoThuTu { get; set; }
    }
}
