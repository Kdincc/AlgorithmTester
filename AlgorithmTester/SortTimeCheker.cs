using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace AlgorithmTester
{
    public class SortTimeCheker : ITimeHandler
    {
        private readonly Stopwatch stopwatch = new Stopwatch();
        private double time = 0;

        public double GetExecutionTime(Action<int[]> algorithm, int[] array)
        {
            time = 0;

            stopwatch.Start();
            algorithm.Invoke(array);
            stopwatch.Stop();

            time = stopwatch.Elapsed.TotalMilliseconds;
            stopwatch.Reset();

            return time;
        }
    }
}
