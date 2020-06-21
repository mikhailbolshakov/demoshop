using DemoShop.Libs.WebApi.ExceptionHandling.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoShop.Libs.Extensions.strings
{
    public static class ToGuidExtension
    {
        public static Guid ToGuid(this string strId)
        {
            Guid userIdGuid;

            if (string.IsNullOrEmpty(strId))
                throw new DsValidationException($"String converted to GUID can not be emtpy or null");

            if (!Guid.TryParse(strId, out userIdGuid))
                throw new DsValidationException($"String must correspond GUID format. Actual: {strId}");

            return userIdGuid;
        }
    }
}
