using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTester
{
    public interface IExecuteTimeManager
    {
        SortedDictionary<string, double> Results { get; }

        void AddResult(string name, Action<int[]> alg, int[] array);
    }
}
