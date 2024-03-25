using FluentValidation;
using Libriary_BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Validators
{
    public class IssueToUpdateDTOValidator : AbstractValidator<IssueToUpdateDTO>
    {
        public IssueToUpdateDTOValidator() 
        {
            RuleFor(r => r.DateOfIssue)
                .NotEmpty()
                .NotNull()
                .LessThanOrEqualTo(r => r.DateOfDelivery)
                .WithMessage("Date must be greater or equals date of delivery");
            RuleFor(r => r.DateOfDelivery)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(r => r.DateOfIssue)
                .WithMessage("Date must be greater or equals date of issue");
            RuleFor(r => r.IssueId)
                .NotEmpty()
                .NotNull()
                .WithMessage("IssueId must be a number");
        }
    }
}
