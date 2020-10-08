using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velox
{
    class VLXException : Exception
    {
        public static string GlobalErrorReport { get; set; } = "";

        public VLXException() : base() { }

        public VLXException(string message) : base(ExceptionFormater(message)) { }

        public VLXException(string message, Exception innerException) : base(ExceptionFormater(message), innerException) { }

        private static string ExceptionFormater(string message)
            => string.Format("*** VLX-Error: {0} *** \r\n\r\nError-Log:\r\n{1}", message, GlobalErrorReport);
    }
}
