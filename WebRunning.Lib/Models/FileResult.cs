﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRunning.Lib.Models
{
    public class FileResult
    {        
        public Guid Id { get; set; } 
        public string Name { get; set; }                       
        public string Path { get; set; }
    }
}
