using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.DTOs
{
    public record BookDTO(int ISBN, string? Title, string? Description, AuthorDTO AuthorDTO, GenreDTO GenreDTO);
}

