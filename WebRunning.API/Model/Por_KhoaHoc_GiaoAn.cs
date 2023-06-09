using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebRunning.Lib.Models;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.Model
{
    [Table("Por_KhoaHoc_GiaoAns")]
    public class Por_KhoaHoc_GiaoAn : AuditEntity
    {
        public Guid IdKhoaHoc { get; set; }
        public Guid IdGiaoAn { get; set; }
        public LoaiGiaoAn LoaiGiaoAnLy { get; set; }
    }
}
