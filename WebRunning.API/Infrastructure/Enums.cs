using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRunning.API.Infrastructure
{
    public class Enums
    {
        public enum NotiType
        {
            RegisteredUser
        }
        public enum FileType
        {
            
        }
        public enum SuKienType
        {
            DaDienRa,
            ChuaDienRa,
            DangDienRa
        }
        public enum GiaoDienPortal
        {
            TrangChu
        }
        public enum LoaiGiaoAn
        {
            GiaoAnLyThuyet,
            GiaoAnThucHanh
        }
        public enum LoaiGiaoAnLyThuyet
        {
            GiaoAn,
            ChuongMuc,
            NoiDung
        }
        public enum LoaiGiaoAnThucHanh
        {
            GiaoAn,
            ChuongMuc,
            BaiHoc,
            NoiDung
        }
    }
}
