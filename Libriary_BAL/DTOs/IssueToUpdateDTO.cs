using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.DTOs
{
    public record IssueToUpdateDTO(int IssueId, DateTime DateOfIssue, DateTime DateOfDelivery, int BookId);
}
