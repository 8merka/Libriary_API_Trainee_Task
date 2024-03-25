using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.DTOs
{
    public record BookToCreateDTO
    {
        public long ISBN { get; init; }
        public string? Title { get; init; }
        public string? Description { get; init; }
        public int AuthorId { get; init; }
        public int GenreId { get; init; }

        public BookToCreateDTO() { }

        public BookToCreateDTO(long ISBN, string? Title, string? Description, int AuthorId, int GenreId)
        {
            this.ISBN = ISBN;
            this.Title = Title;
            this.Description = Description;
            this.AuthorId = AuthorId;
            this.GenreId = GenreId;
        }
    }
}
