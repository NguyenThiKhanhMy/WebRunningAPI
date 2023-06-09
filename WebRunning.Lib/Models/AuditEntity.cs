using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebRunning.Lib.Core;
using WebRunning.Lib.Enums;

namespace WebRunning.Lib.Models
{
    abstract public class AuditEntity
    {
        [Key]
        [ColumnNameAttr("category")]
        public Guid Id { get; set; }

        //[JsonIgnore]
        public DateTimeOffset CreatedDateTime { get; set; }

        [StringLength(55)]
        [JsonIgnore]
        public string CreatedBy { get; set; }

        //[JsonIgnore]
        public DateTimeOffset? UpdatedDateTime { get; set; }

        [StringLength(55)]
        [JsonIgnore]
        public string UpdatedBy { get; set; }

        [StringLength(10)]
        [JsonIgnore]
        public string TenantCode { get; set; }
    }
}
