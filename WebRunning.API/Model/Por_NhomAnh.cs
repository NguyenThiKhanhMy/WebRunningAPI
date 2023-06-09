using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using WebRunning.Lib.Models;
using WebRunning.Lib.Core;

namespace WebRunning.API.Model
{
    [Table("Por_NhomAnhs")]
    public class Por_NhomAnh : AuditEntity
    {
        [StringLength(55)]
        public string Ma { get; set; }
        [StringLength(55)]
        [ColumnNameAttr("category")]
        public string Ten { get; set; }
    }
}
