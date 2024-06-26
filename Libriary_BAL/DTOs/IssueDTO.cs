﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.DTOs
{
    public record IssueDTO
    {
        public DateTime DateOfIssue { get; init; }
        public DateTime DateOfDelivery { get; init; }
        public BookDTO bookDTO { get; init; }

        public IssueDTO() { }

        public IssueDTO(DateTime DateOfIssue, DateTime DateOfDelivery, BookDTO bookDTO)
        {
            this.DateOfIssue = DateOfIssue;
            this.DateOfDelivery = DateOfDelivery;
            this.bookDTO = bookDTO;
        }
    };
}
