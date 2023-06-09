using System;
using WebRunning.Lib.Models;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.ViewModel.Portal
{
    public class DsSuKien
    {
        public Guid Id { get; set; }
        public Guid IdNhomSuKien { get; set; }
        public string NhomSuKien { get; set; }
        public string URL_AnhDaiDien { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public SuKienType TrangThai { get; set; }
        public double GiaTien { get; set; }
        public DateTimeOffset ThoiGian { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public bool TrangThaiBanGhi { get; set; }
    }
}