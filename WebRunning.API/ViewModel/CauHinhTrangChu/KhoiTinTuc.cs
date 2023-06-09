using System;
using System.ComponentModel.DataAnnotations;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.ViewModel.CauHinhTrangChu
{
    public class KhoiTinTuc
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string URL_AnhDaiDien { get; set; }
        public string MoTa { get; set; }
    }
}
