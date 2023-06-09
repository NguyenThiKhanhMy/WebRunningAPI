using System;
using System.Collections.Generic;
using WebRunning.Lib.Models;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.ViewModel.Portal
{
    public class ObjNhomSuKien
    {
        public string TenNhomSuKien { get; set; }
        public Guid idNhomSuKien { get; set; }
        public List<ObjSuKien> DanhSachSuKien { get; set; }
    }
}