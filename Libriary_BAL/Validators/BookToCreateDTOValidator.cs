using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Libriary_BAL.DTOs;

namespace Libriary_BAL.Validators
{
    public class BookToCreateDTOValidator : AbstractValidator<BookToCreateDTO>
    {
        public BookToCreateDTOValidator()
        {
            RuleFor(r => r.ISBN)
                .NotNull() 
                .NotEmpty()
                .Must(n => n.ToString().Length == 13)
                .WithMessage("ISBN must be exact 13 digits.");
            RuleFor(r => r.Title)
                .NotNull()
                .NotEmpty();
            RuleFor(r => r.Description)
                .NotNull()
                .NotEmpty();
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
