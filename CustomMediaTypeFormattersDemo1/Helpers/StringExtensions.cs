using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomMediaTypeFormattersDemo.Helpers
{
    public static class StringExtensions
    {
        public static string NormalizeName(this string value)
        {
            return value.Replace("\"", "");
        }
    }
}