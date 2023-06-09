using System;
using System.Collections.Generic;
using WebRunning.Lib.Models;

namespace WebRunning.API.ViewModel.Portal
{
    public class ObjMonHoc
    {
        public Guid IdMonHocCha { get; set; }
        public string URL_AnhDaiDien { get; set; }
        public string TenMonHoc { get; set; }
        public string MoTa { get; set; }
        public double GiaGiaoDongTu { get; set; }
        public double GiaGiaoDongDen { get; set; }
        public Guid Id { get; set; }
        public List<ObjMonHoc> DanhSachMonHocCon { get; set; }
    }
}
