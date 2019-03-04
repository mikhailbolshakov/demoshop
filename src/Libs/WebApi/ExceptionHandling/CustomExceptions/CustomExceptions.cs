using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Libs.WebApi.ExceptionHandling.CustomExceptions
{
    public class DsCustomException : Exception
    {
        public DsCustomException() : base() { }
        public DsCustomException(string message) : base(message) { }
        public DsCustomException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class DsValidationException : DsCustomException
    {
        public DsValidationException(string message) : base(message) { }
    }

    public class DsNotFoundException : DsCustomException
    {
        public DsNotFoundException(string message) : base(message) { }
    }
}
