using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.DTOs
{
   public record BookToUpdateDTO(int BookId, GenreDTO GenreDTO, AuthorDTO AuthorDTO, int ISBN, string? title, string? description);
}
