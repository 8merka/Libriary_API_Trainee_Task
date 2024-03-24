using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.DTOs
{
    public record IssueToCreateDTO
    {
        public DateTime DateOfIssue { get; init; }
        public DateTime DateOfDelivery { get; init; }
        public int BookId { get; init; }

        public IssueToCreateDTO() { }

        public IssueToCreateDTO(DateTime DateOfIssue, DateTime DateOfDelivery, int bookId)
        {
            this.DateOfIssue = DateOfIssue;
            this.DateOfDelivery = DateOfDelivery;
            this.BookId = bookId;
        }
    };
}
