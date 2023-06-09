using System;
using WebRunning.Lib.Models;

namespace WebRunning.API.ViewModel.Portal
{
    public class ObjKhoaHoc
    {
        public Guid Id { get; set; }
        public string TieuDe { get; set; }
        public int ThoiHan { get; set; }
        public string GioiThieu { get; set; }
        public string URL_AnhDaiDien { get; set; }
        public double HocPhiGoc { get; set; }
        public double HocPhiGiamGia { get; set; }
        public Guid IdMonHoc { get; set; }
    }
}