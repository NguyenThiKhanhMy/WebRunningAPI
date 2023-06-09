using WebRunning.Lib.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.Lib.Enums;
using static WebRunning.API.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebRunning.API.ViewModel.Por_GiaoAnLyThuyet
{
    public class GiaoAnLyThuyetTree : absTree<GiaoAnLyThuyetTree>
    {
        public LoaiGiaoAnLyThuyet Loai { get; set; }
        public int SoThuTu { get; set; }
        public double ThoiLuong { get; set; }
        public bool MienPhi { get; set; }
    }
}
