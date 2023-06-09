using WebRunning.Lib.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.Lib.Enums;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.ViewModel.Por_GiaoAnThucHanh
{
    public class GiaoAnThucHanhTree : absTree<GiaoAnThucHanhTree>
    {
        public LoaiGiaoAnThucHanh Loai { get; set; }
        public string GhiChu { get; set; }
        public int SoThuTu { get; set; }
        public double ThoiLuong { get; set; }
        public bool MienPhi { get; set; }
    }
}
