using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebRunning.Lib.Models;

namespace WebRunning.API.Model
{
    [Table("Por_TinTucs")]
    public class Por_TinTuc : AuditEntity
    {
        [StringLength(200)]
        public string TieuDe { get; set; }
        [StringLength(500)]
        public string MoTa { get; set; }
        [MaxLength]
        public string NoiDung { get; set; }
        [StringLength(100)]
        public string TacGia { get; set; }
        [StringLength(500)]
        public string URL_AnhDaiDien { get; set; }
        public DateTimeOffset NgayXuatBan { get; set; }
        public bool TinNoiBat { get; set; }
        //public bool TinMoi { get; set; }
        public int LuotXem { get; set; }
        public Guid IdNhomTinTuc { get; set; }
        public bool TrangThaiBanGhi { get; set; }
    }
}
