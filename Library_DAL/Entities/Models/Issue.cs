using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_DAL.Entities.Models
{
    public class Issue
    {
        public int IssueId { get; set; }
        public int BookId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfDelivery { get; set; }   

        public Book Book { get; set; }
    }
}
