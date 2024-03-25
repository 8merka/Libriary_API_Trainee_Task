using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.DTOs
{
    public record BookDTO
    {
        public long ISBN { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public AuthorDTO AuthorDTO { get; init; }
        public GenreDTO GenreDTO { get; init; }

        public BookDTO() { }

        public BookDTO(long ISBN, string? Title, string? Description, AuthorDTO AuthorDTO, GenreDTO GenreDTO)
        {
            this.ISBN = ISBN;
            this.Title = Title;
            this.Description = Description;
            this.AuthorDTO = AuthorDTO;
            this.GenreDTO = GenreDTO;
        }
    }
}

