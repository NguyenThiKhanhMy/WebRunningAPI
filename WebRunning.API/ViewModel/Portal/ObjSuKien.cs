using System;
using WebRunning.Lib.Models;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.ViewModel.Portal
{
    public class ObjSuKien
    {
        public Guid IdSuKien { get; set; }
        public string TenSuKien { get; set; }
        public string DiaChi { get; set; }
        public string MoTa { get; set; }
        public string GiaTien { get; set; }
        public DateTimeOffset ThoiGian { get; set; }
        public string URL_AnhDaiDien { get; set; }
        public SuKienType TrangThai { get; set; }
    }
}