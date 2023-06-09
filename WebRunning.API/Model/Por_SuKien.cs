using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebRunning.Lib.Models;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.Model
{
    [Table("Por_SuKiens")]
    public class Por_SuKien : AuditEntity
    {
        [StringLength(155)]
        public string Ten { get; set; }
        [StringLength(255)]
        public string DiaChi { get; set; }
        [MaxLength]
        public string NoiDung { get; set; }
        public double GiaTien { get; set; }
        public DateTimeOffset ThoiGian { get; set; }
        [StringLength(500)]
        public string URL_AnhDaiDien { get; set; }
        public SuKienType TrangThai { get; set; }
        public Guid IdNhomSuKien { get; set; }
        public bool TrangThaiBanGhi { get; set; }
    }
}
