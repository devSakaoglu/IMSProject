using InternshipManagementSystem.Application.ViewModels;
using InternshipManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Features.Student.Queries.GetStudentById.cs
{
using Student = InternshipManagementSystem.Domain.Entities.Student;

    public class GetStudentByIdQueryResponse : IRequest<GetStudentByIdQueryResponse>
    {
        public Student student { get; set; }


    }
}
