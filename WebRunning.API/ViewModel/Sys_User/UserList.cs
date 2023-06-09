﻿using WebRunning.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRunning.API.ViewModel.Sys_User
{
    public class UserList
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public string FullName { get; set; }        
        public string UserName { get; set; }
        public string Email { get; set; }        
        public string Phone { get; set; }                
        public bool IsActive { get; set; } 
    }
}
