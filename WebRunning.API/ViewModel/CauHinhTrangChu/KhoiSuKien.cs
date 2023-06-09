using System;
using System.ComponentModel.DataAnnotations;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.ViewModel.CauHinhTrangChu
{
    public class KhoiSuKien
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string URL_AnhDaiDien { get; set; }
        public DateTimeOffset ThoiGian { get; set; }
        public double GiaTien { get; set; }
        public SuKienType TrangThai { get; set; }
    }
}
