﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Utilities.Exceptions
{
        public class NotFoundException(string message) : Exception(message) { }
}
