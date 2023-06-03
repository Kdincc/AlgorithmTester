using System;
using System.Linq;
using System.Windows.Controls;

namespace AlgorithmTester
{
    public static class TextBoxExtension
    {
        public static int[] GetArray(this TextBox textBox)
        {
            var numbers = textBox.Text.Split(',', StringSplitOptions.RemoveEmptyEntries);

            var array = numbers.Select(x => Convert.ToInt32(x)).ToArray();

            return array;
        }
    }
}
