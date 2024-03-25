using FluentValidation;
using Libriary_BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Validators
{
    public class GenreToUpdateDTOValidator : AbstractValidator<GenreToUpdateDTO>
    {
        public GenreToUpdateDTOValidator()
        {
            RuleFor(r => r.GenreId)
                .NotEmpty()
                .NotNull()
                .WithMessage("GenreId field must be a number");
            RuleFor(r => r.BookGenre)
                .NotNull();
        }
    }
}
