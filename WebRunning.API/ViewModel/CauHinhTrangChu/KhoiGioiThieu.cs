using System;
using System.ComponentModel.DataAnnotations;

namespace WebRunning.API.ViewModel.CauHinhTrangChu
{
    public class KhoiGioiThieu
    {
        public string TieuDeGioiThieu { get; set; }
        public Guid Id { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string URL_AnhDaiDien { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
    }
}
