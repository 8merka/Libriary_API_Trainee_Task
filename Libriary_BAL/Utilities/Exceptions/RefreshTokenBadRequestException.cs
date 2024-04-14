using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Utilities.Exceptions
{
    public class RefreshTokenBadRequestException(string message) : Exception(message) { }
}
