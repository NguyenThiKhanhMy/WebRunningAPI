using WebRunning.Lib.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.Lib.Enums;
using WebRunning.API.ViewModel.Por_GiaoAnLyThuyet;
using WebRunning.API.ViewModel.Por_GiaoAnThucHanh;

namespace WebRunning.API.ViewModel.Por_KhoaHoc
{
    public class KhoaHocThu
    {
        public Guid Id { get; set; }
        public string TieuDe { get; set; }
        public List<GiaoAnLyThuyetTree> GiaoAnLyThuyet { get; set; }
        public List<GiaoAnThucHanhTree> GiaoAnThucHanh { get; set; }
    }
}
