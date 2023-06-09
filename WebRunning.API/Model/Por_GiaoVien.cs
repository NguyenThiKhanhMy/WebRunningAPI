using WebRunning.Lib.Enums;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.Lib.Core;

namespace WebRunning.API.Model
{
    [Table("Por_GiaoVien")]
    public class Por_GiaoVien: AuditEntity
    {
        [StringLength(55)]
        public string URLAnhDaiDien { get; set; }
        [StringLength(55)]
        public string Ma { get; set; }
        [StringLength(55)]
        [ColumnNameAttr("category")]
        public string Ten { get; set; }
        [StringLength(55)]
        public string NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        [StringLength(55)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string ChungChi { get; set; }
        [StringLength(100)]
        public string ThanhTich { get; set; }
    }
}
