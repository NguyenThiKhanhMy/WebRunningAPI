using System;
using WebRunning.Lib.Models;

namespace WebRunning.API.ViewModel.Portal
{
    public class DsVideo
    {
        public Guid Id { get; set; }
        public string NhomVideo { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public double ThoiLuong { get; set; }
    }
}