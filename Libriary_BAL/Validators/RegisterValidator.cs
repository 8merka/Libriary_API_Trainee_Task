using FluentValidation;
using Libriary_BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.Username)
                .MaximumLength(30).WithMessage("Username must be shorter than 30 symbols")
                .NotEmpty().WithMessage("Username should not be empty");

            RuleFor(r => r.Email)
                .EmailAddress()
                .NotEmpty().WithMessage("Email should not be empty");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Password should not be empty")
                .MinimumLength(4).WithMessage("Password must be at least 4")
                .MaximumLength(20).WithMessage("Password must not exceed 20")
                .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter")
                .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter")
                .Matches(@"[0-9]+").WithMessage("Password must contain at least one digit")
                .Matches(@"[\!\?\*\.]+").WithMessage("Password must contain at least one special character");

            RuleFor(r => r.ConfirmPassword)
                .Equal(r => r.Password).WithMessage("This must match to Password");
        }
    }
}
