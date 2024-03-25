using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.DTOs
{
   public record BookToUpdateDTO(int BookId, int AuthorId, int GenreId, long ISBN, string? title, string? description);
}
