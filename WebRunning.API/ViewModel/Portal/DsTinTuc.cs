using System;
using WebRunning.Lib.Models;

namespace WebRunning.API.ViewModel.Portal
{
    public class DsTinTuc
    {
        public Guid Id { get; set; }
        public Guid IdNhomTinTuc { get; set; }
        public string URL_AnhDaiDien { get; set; }
        public string NhomTinTuc { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string TacGia { get; set; }
        public DateTimeOffset NgayXuatBan { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public bool? TinMoi { get; set; }
        public bool? TinNoiBat { get; set; }
        public bool TrangThaiBanGhi { get; set; }
    }
}