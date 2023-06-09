using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebRunning.Lib.Core;

namespace WebRunning.API.Model
{
    [Table("Sys_Roles")]
    public class Sys_Role : AuditEntity
    {
        [StringLength(55)]
        [ColumnNameAttr("category")]
        public string Code { get; set; }
        [StringLength(55)]
        [ColumnNameAttr("category")]
        public string Name { get; set; }      
    }
}
