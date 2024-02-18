using InternshipManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace InternshipManagementSystem.Application.Features.Internship.Commands.CreateInternship
{
    public class CreateInternshipCommandRequest : IRequest<CreateInternshipCommandResponse>
    {
        [Required]
        public Guid AdvisorID { get; set; }

        [Required]
        public Guid StudentID { get; set; }

        [Required]
        public string StudentNo { get; set; }

        [Required]
        public IFormFile formFile { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string TC_NO { get; set; }

        [Required]
        public string InternshipStartDate { get; set; }

        [Required]
        public string InternshipEndDate { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string StudentGSMNumber { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public int NumberOfEmployees { get; set; }

        [Required]
        public string CompanyPhone { get; set; }

        [Required]
        public string CompanyAddress { get; set; }

        [Required]
        public double RequestedGovernmentAidAmount { get; set; }

        [Required]
        public bool ReceivesSalary { get; set; }

        [Required]
        public bool DoesNotReceiveSalary { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public bool ReceivesHealthInsurance { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }//

        [Required]
        public string EmailSendingDate { get; set; }

        [Required]
        public InternshipLevel Level { get; set; }
    }

    }
}
