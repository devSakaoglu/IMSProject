﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.DTO
{
    public class InternshipDocumentDTO
    {
        public Guid InternshipID { get; set; }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public string path{ get; set; } 
        //public IFormFile File { get; set; }
    }
}
