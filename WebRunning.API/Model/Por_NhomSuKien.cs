using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebRunning.Lib.Models;
using WebRunning.Lib.Core;

namespace WebRunning.API.Model
{
    [Table("Por_NhomSuKiens")]
    public class Por_NhomSuKien : AuditEntity
    {
        [StringLength(55)]
        public string Ma { get; set; }
        [StringLength(55)]
        [ColumnNameAttr("category")]
        public string Ten { get; set; }
        public bool TrangThaiBanGhi { get; set; }
    }
}
