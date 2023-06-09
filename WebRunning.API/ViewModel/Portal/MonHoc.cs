using System;
using System.Collections.Generic;
using WebRunning.Lib.Models;

namespace WebRunning.API.ViewModel.Portal
{
    public class MonHoc
    {
        public string TenMonHoc { get; set; }
        public Guid IdMonHoc { get; set; }
        public List<ObjKhoaHoc> DanhSachKhoaHoc { get; set; }
    }
}
