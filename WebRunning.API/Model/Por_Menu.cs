using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using WebRunning.Lib.Models;
using WebRunning.Lib.Core;

namespace WebRunning.API.Model
{
    [Table("Por_Menus")]
    public class Por_Menu : AuditEntity
    {
        public int ThuTu { get; set; }
        [StringLength(55)]
        public string Ma { get; set; }
        [StringLength(55)]
        public string Ten { get; set; }
        [StringLength(55)]
        public string URL { get; set; }
        public Guid IdMenuCha { get; set; }
        public bool TrangThaiBanGhi { get; set; }
    }
}  
