using System.Text.RegularExpressions;

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
