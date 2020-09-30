using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velox
{
    class VLXException : Exception
    {
        public VLXException() : base() { }

        public VLXException(string message) : base(ExceptionFormater(message)) { }

        public VLXException(string message, Exception innerException) : base(ExceptionFormater(message), innerException) { }

        private static string ExceptionFormater(string message)
            => string.Format("*** VLX-Error: {0} ***", message);
    }
}
