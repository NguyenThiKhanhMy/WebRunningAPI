using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using WebRunning.Lib.Models;

namespace WebRunning.API.Model
{
    [Table("Por_Videos")]
    public class Por_Video : AuditEntity
    {
        [StringLength(55)]
        public string Ma { get; set; }
        [StringLength(55)]
        public string Ten { get; set; }
        [StringLength(500)]
        public string URL_Video { get; set; }
        public double ThoiLuong { get; set; }
        public Guid IdNhomVideo { get; set; }
    }
}
