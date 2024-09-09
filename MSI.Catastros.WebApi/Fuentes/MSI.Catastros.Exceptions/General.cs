using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSI.Catastros.Exceptions
{
    public class General
    {
        public enum ExceptionType
        {
            Warning = 1,
            Error = 2,
            Success = 3,
            Info = 4,
        }
    }
}
