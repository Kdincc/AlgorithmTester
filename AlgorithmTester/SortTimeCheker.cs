using System;
using System.Diagnostics;

namespace AlgorithmTester
{
    public class SortTimeCheker : IMeasurmentsHandler
    {
        private readonly Stopwatch stopwatch = new Stopwatch();
        private double time = 0;

        public double GetMeasurments(Action<int[]> algorithm, int[] array)
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
