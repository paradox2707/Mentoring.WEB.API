using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentoring.WEB.API.Common
{
    public class ValidationAppException : Exception
    {
        public ValidationAppException(string message) : base(message)
        {
        }
    }
}
