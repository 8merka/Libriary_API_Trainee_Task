using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.DTOs
{
    public record IssueDTO(DateTime DateOfIssue, DateTime DateOfDelivery, BookDTO BookDTO);
}
