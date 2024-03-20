using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_DAL.Entities.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string? BookGenre { get; set; }

        public List<Book> Books { get; set; }
    }
}
