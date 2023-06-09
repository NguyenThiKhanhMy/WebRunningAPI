using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebRunning.Lib.Models;
using WebRunning.Lib.Core;
using System.Collections.Generic;

namespace WebRunning.API.Model
{
    [Table("Por_MonHocs")]
    public class Por_MonHoc : AuditEntity
    {
        [StringLength(55)]
        public string Ma { get; set; }
        [StringLength(55)]
        [ColumnNameAttr("category")]
        public string Ten { get; set; }
        [StringLength(500)]
        public string MoTa { get; set; }
        [StringLength(500)]
        public string URL_AnhDaiDien { get; set; }
        public double GiaGiaoDongTu { get; set; }
        public double GiaGiaoDongDen { get; set; }
        public Guid IdMonHocCha { get; set; }
        public bool TrangThaiBanGhi { get; set; }
    }
}
