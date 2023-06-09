using System;
using System.Collections.Generic;
using WebRunning.Lib.Models;
using static WebRunning.API.Infrastructure.Enums;

namespace WebRunning.API.ViewModel.Portal
{
    public class ObjNhomTinTucItems
    {
        public string TenNhomTinTuc { get; set; }
        public Guid IdNhomTintuc { get; set; }
        public ObjTinTuc objTinTuc;
    }
}