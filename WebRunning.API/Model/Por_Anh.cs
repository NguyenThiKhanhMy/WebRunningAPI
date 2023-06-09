using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using WebRunning.Lib.Models;

namespace WebRunning.API.Model
{
    [Table("Por_Anhs")]
    public class Por_Anh : AuditEntity
    {
        [StringLength(55)]
        public string Ma { get; set; }
        [StringLength(55)]
        public string Ten { get; set; }
        [StringLength(500)]
        public string URL_Anh { get; set; }
        public Guid IdNhomAnh { get; set; }
    }
}
