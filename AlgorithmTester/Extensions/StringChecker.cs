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

            Regex regex = new Regex(ARRAY_PATERN);

            if (regex.IsMatch(str))
            {
                return true;
            }

            return false;
        }
    }
}
