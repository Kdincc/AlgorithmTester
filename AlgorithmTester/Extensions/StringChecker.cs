using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlgorithmTester.Extensions
{
    public static class StringChecker
    {
        public static bool IsArrayString(this string str)
        {
            const string ARRAY_PATERN = "^\\d+(,\\d+)*$";
            const string ARRAY_PATERN_WITH_SPACES = "^\\d+\\s*(,\\s*\\d+)*$\r\n";

            Regex regex = new Regex(ARRAY_PATERN);
            Regex spaceRegex = new Regex(ARRAY_PATERN_WITH_SPACES);

            if (regex.IsMatch(str) || spaceRegex.IsMatch(str))
            {
                return true;
            }

            return false;
        }
    }
}
