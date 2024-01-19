using FluentValidation;
using InternshipManagementSystem.Application.ViewModels.AdvisorViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipManagementSystem.Application.Validators.Advisor
{
    public class UpdateAdvisorValidator : AbstractValidator<VM_Update_Advisor>
    {
        public UpdateAdvisorValidator()
        {
            RuleFor(x => x.AdvisorName)
             .NotEmpty().WithMessage("Advisor name cannot be empty.")
             .NotNull().WithMessage("Advisor name cannot be null.")
             .MaximumLength(256).WithMessage("Advisor name must be at most 256 characters.");

            RuleFor(x => x.AdviserSurname)
                .NotEmpty().WithMessage("Advisor surname cannot be empty.")
                .NotNull().WithMessage("Advisor surname cannot be null.")
                .MaximumLength(256).WithMessage("Advisor surname must be at most 256 characters.");

            RuleFor(x => x.TC_No)
                .NotEmpty().WithMessage("TC number cannot be empty.")
                .NotNull().WithMessage("TC number cannot be null.")
                .Must(x => long.TryParse(x.ToString(), out _)).WithMessage("TC number must be numeric.")
                .Must(x => long.Parse(x.ToString()) % 2 == 0).WithMessage("TC number must be an even value.")
                .Must(x => x.ToString().Length == 11).WithMessage("TC number must be 11 characters.");

            RuleFor(x => x.FacultyName)
                .NotEmpty().WithMessage("Faculty name cannot be empty.")
                .NotNull().WithMessage("Faculty name cannot be null.")
                .MaximumLength(256).WithMessage("Faculty name must be at most 256 characters.");

            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("Department name cannot be empty.")
                .NotNull().WithMessage("Department name cannot be null.")
                .MaximumLength(256).WithMessage("Department name must be at most 256 characters.");

            RuleFor(x => x.ProgramName)
                .NotEmpty().WithMessage("Program name cannot be empty.")
                .NotNull().WithMessage("Program name cannot be null.")
                .MaximumLength(256).WithMessage("Program name must be at most 256 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address cannot be empty.")
                .NotNull().WithMessage("Address cannot be null.")
                .MaximumLength(256).WithMessage("Address must be at most 256 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .NotNull().WithMessage("Email cannot be null.")
                .MaximumLength(256).WithMessage("Email must be at most 256 characters.")
                .EmailAddress().WithMessage("It is not a valid email address.");

        }

    }
}
