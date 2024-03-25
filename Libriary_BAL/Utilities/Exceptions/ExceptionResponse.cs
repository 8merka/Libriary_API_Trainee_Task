using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Libriary_BAL.Utilities.Exceptions
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Message);
}
