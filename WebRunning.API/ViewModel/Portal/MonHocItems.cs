using System;
using WebRunning.API.Model;
using WebRunning.Lib.Models;

namespace WebRunning.API.ViewModel.Portal
{
    public class MonHocItems
    {
        public string TenMonHoc { get; set; }
        public Guid IdMonHoc { get; set; }

        public ObjKhoaHoc objKhoaHoc;
    }
}
