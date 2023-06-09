using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebRunning.Lib.Models;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.Model
{
    [Table("Por_GiaoAnLyThuyets")]
    public class Por_GiaoAnLyThuyet : AuditEntity
    {
        public Guid IdGiaoAnLyThuyet { get; set; }
        public LoaiGiaoAnLyThuyet Loai { get; set; }
        [StringLength(250)]
        public string TieuDe { get; set; }
        [StringLength(500)]
        public string URL_Video { get; set; }
        public double ThoiLuong { get; set; }
        public bool MienPhi { get; set; }
        public int SoThuTu { get; set; }
    }
}
