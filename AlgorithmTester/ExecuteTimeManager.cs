using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTester
{
    public class ExecuteTimeManager : IExecuteTimeManager
    {
        public SortedDictionary<string, double> Results { get; }
        private ITimeHandler _timeHandler;
        private double time = 0;

        public ExecuteTimeManager(ITimeHandler timeHandler)
        {
            Results = new SortedDictionary<string, double>();
            _timeHandler = timeHandler;
        }

        public void AddResult(string name, Action<int[]> alg, int[] array)
        {
            int[] tempArray = new int[array.Length];
            array.CopyTo(tempArray, 0);

            time = _timeHandler.GetExecutionTime(alg, tempArray);
            Results.Add(name, time);
        }
    }
}
