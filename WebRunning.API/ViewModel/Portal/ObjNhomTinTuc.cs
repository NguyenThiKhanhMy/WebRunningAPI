using System;
using System.Collections.Generic;
using WebRunning.Lib.Models;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.ViewModel.Portal
{
    public class ObjNhomTinTuc
    {
        public string TenNhomTinTuc { get; set; }
        public Guid IdNhomTinTuc { get; set; }
        public List<ObjTinTuc> DanhSachTinTuc { get; set; }
        public List<ObjKienThuc> DanhSachKienThuc { get; set; }
    }
}