using WebRunning.Lib.Enums;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebRunning.API.Model
{
    [Table("Sys_Permissions")]
    public class Sys_Permission:AuditEntity
    {                
        public Guid RoleId { get; set; }
        public Guid ResourceId { get; set; }
        public bool IsFunc { get; set; }
    }
}
