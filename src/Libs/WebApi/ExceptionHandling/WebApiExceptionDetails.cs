using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Libs.WebApi.ExceptionHandling
{
    public class WebApiExceptionDetails
    {
        /// <summary>
        /// HTTP status code
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Error user-friendly message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// exception stack trace
        /// </summary>
        public string StackTrace { get; set; }

        /// <summary>
        /// string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
