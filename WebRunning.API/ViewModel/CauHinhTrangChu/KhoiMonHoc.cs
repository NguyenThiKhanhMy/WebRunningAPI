using System;
using System.ComponentModel.DataAnnotations;

namespace WebRunning.API.ViewModel.CauHinhTrangChu
{
    public class KhoiMonHoc
    {
        public Guid Id { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string URL_AnhDaiDien { get; set; }
        public double GiaGiaoDongTu { get; set; }
        public double GiaGiaoDongDen { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
    }
}
