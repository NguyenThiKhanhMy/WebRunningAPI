using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebRunning.Lib.Models;

namespace WebRunning.API.Model
{
    [Table("Por_LoaiKhoaHocs")]
    public class Por_LoaiKhoaHoc : AuditEntity
    {
        [StringLength(55)]
        public string Ma { get; set; }
        [StringLength(200)]
        public string TieuDe { get; set; }
        public bool TrangThaiBanGhi { get; set; }

    }
}
