﻿using WebRunning.Lib.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRunning.Lib.Enums;

namespace WebRunning.API.ViewModel.Sys_Organization
{
    public class OrganTree : absTree<OrganTree>
    {
        public OrganizationType Type { get; set; }
    }
}
