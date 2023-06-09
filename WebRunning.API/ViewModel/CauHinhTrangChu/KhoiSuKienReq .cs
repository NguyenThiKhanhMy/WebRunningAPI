using System;
using System.ComponentModel.DataAnnotations;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.ViewModel.CauHinhTrangChu
{
    public class KhoiSuKienReq
    {
        public SuKienType[] TinhTrang { get; set; }
        public int SoLuong { get; set; }

    }
}
