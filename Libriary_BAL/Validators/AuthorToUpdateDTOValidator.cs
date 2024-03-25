using FluentValidation;
using Libriary_BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Validators
{
    public class AuthorToUpdateDTOValidator : AbstractValidator<AuthorToUpdateDTO>
    {
        public AuthorToUpdateDTOValidator() 
        {
            RuleFor(r => r.AuthorId)
                .NotEmpty()
                .NotNull()
                .WithMessage("AuthorId must be a number");
            RuleFor(r => r.Name) 
                .NotEmpty()
                .WithMessage("Name field should not be empty");
            RuleFor(r => r.LastName)
                .NotEmpty()
                .WithMessage("LastName field should not be empty");

        }
    }
}
