﻿using InternshipManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.DTO
{
    public class AdvisorDTO
    {
        public string FacultyName { get; set; }
        public string AdvisorName { get; set; }
        public string AdviserSurname { get; set; }
        public string TC_No { get; set; }
        public string DepartmentName { get; set; }
        public string ProgramName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

    }
}
