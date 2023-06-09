﻿using WebRunning.Lib.Enums;
using WebRunning.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebRunning.API.Model
{
    [Table("Sys_Users_Roles")]
    public class Sys_User_Role
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? OrganId { get; set; }
        public bool IsDefault { get; set; }
        public Guid? MenuId { get; set; }
    }
}
