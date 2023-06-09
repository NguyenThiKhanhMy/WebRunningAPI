using System;
using WebRunning.Lib.Models;

namespace WebRunning.API.ViewModel.Portal
{
    public class ObjTinTuc
    {
        public Guid Id { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string URL_AnhDaiDien { get; set; }
    }
}