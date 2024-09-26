using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace Eshop.Data
{
    public static class Helpers
    {
        public const string ToStringParamsSeparator = ", ";

        public static string ArrayToString<T>(this IList<T> list)
        {
            string s = "";
            foreach (T item in list)
            {
                if (item != null)
                    s += item.ToString() + ToStringParamsSeparator;
            }
            return s;
        }

    }
    public static class ConsoleLoggerFactory
    {
        public static ILoggerFactory Create()
        {
            return LoggerFactory.Create(builder => { builder.AddConsole(); });
        }
    }
}
