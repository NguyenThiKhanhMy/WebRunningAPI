﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRunning.Lib.Models
{
    public class ForgetPasswordRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
