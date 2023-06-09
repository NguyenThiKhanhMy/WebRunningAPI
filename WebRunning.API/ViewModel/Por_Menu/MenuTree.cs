using WebRunning.Lib.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.Lib.Enums;

namespace WebRunning.API.ViewModel.Por_Menu
{
    public class MenuTree : absTree<MenuTree>
    {
        public MenuType Type { get; set; }
        public string URL { get; set; }
        public int ThuTu { get; set; }
    }
}
