using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebRunning.Lib.Models;
using WebRunning.Lib.Enums;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.Model
{
    [Table("Por_CauHinhGiaoDiens")]
    public class Por_CauHinhGiaoDien : AuditEntity
    {
        public GiaoDienPortal GiaoDien { get; set; }
        [MaxLength]
        public string NoiDung { get; set; }
    }
}
