using System;
using System.ComponentModel.DataAnnotations;

namespace WebRunning.API.ViewModel.CauHinhTrangChu
{
    public class KhoiKhoaHocReq
    {
        public string MaMonHoc { get; set; }
        public string MaLoai { get; set; }
        public int SoLuong { get; set; }
    }
}
