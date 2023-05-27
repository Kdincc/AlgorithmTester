using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AlgorithmTester
{
    public static class TextBoxExtension
    {
        public static int[] GetArray(this TextBox textBox)
        {
            var numbers = textBox.Text.Split(',');
            
            var array = numbers.Select(x => Convert.ToInt32(x)).ToArray();

            return array;
        }
    }
}
