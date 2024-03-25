using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_DAL.Entities.Models
{
    public class Book
    {
        public int BookId {  get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public long ISBN { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public List<Issue> Issues { get; set; } = new List<Issue>();
        public Author Author { get; set; }
        public Genre Genre { get; set; }
    }
}
