using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareX_Log_Automation_Console.Helpers
{
    internal static class PathExtensionMethods
    {
        public static string NormalizePath(this string path)
        {
            string np = path;
            // check if last character of path is '\'
            if (np[^1..] == "\\")
            {
                np = np[..^1];
            }
            return new Uri(np).LocalPath;
        }
    }
}
