using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using WebRunning.Lib.Models;

namespace WebRunning.API.Model
{
    [Table("Por_ChiTietGioHangs")]
    public class Por_ChiTietGioHang : AuditEntity
    {
        public Guid IdKhoaHoc { get; set; }
        public double GiaTien { get; set; }
    }
}
