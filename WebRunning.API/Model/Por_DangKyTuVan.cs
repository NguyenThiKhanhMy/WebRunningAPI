using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using WebRunning.Lib.Models;

namespace WebRunning.API.Model
{
    [Table("Por_DangKyTuVans")]
    public class Por_DangKyTuVan : AuditEntity
    {
        [StringLength(155)]
        public string Ten { get; set; }
        public int GioiTinh { get; set; }
        [StringLength(20)]
        public string Sdt { get; set; }
        [StringLength(55)]
        public string Email { get; set; }
        [StringLength(500)]
        public string NoiDung { get; set; }
    }
}