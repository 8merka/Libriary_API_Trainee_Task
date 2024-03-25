using FluentValidation;
using Libriary_BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Validators
{
    public class BookToUpdateDTOValidator : AbstractValidator<BookToUpdateDTO>
    {
        public BookToUpdateDTOValidator() 
        {
            RuleFor(r => r.ISBN)
                .NotNull()
                .NotEmpty()
                .Must(n => n.ToString().Length == 13)
                .WithMessage("ISBN must be exact 13 digits.");
            RuleFor(r => r.title)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.description)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.BookId)
                .NotNull()
                .NotEmpty()
                .WithMessage("BookId must be a number");
            RuleFor(r => r.AuthorId)
                .NotNull()
                .NotEmpty()
                .WithMessage("AuthorId must be a number");
            RuleFor(r => r.GenreId)
                .NotNull()
                .NotEmpty()
                .WithMessage("GenreId must be a number");

        }
    }
}
