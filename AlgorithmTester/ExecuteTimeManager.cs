using System;
using System.Collections.Generic;

namespace AlgorithmTester
{
    public class ExecuteTimeManager : IMeasurmentsManager
    {
        public Dictionary<string, double> Results { get; }
        private readonly IMeasurmentsHandler _measurmentHandler;
        private double totalMeasurments = 0;
        private const int AMOUNT_MEASUREMENTS = 5;

        public ExecuteTimeManager(IMeasurmentsHandler timeHandler)
        {
            Results = new Dictionary<string, double>();
            _measurmentHandler = timeHandler;
        }

        public void AddResult(string name, Action<int[]> alg, int[] array)
        {
            double measurmentSum = 0;
            int[] tempArray = new int[array.Length];

            for (int i = 0; i < AMOUNT_MEASUREMENTS; i++)
            {
                array.CopyTo(tempArray, 0);
                measurmentSum += _measurmentHandler.GetMeasurments(alg, tempArray);
            }

            totalMeasurments = Math.Round(measurmentSum / AMOUNT_MEASUREMENTS, 4);

            Results.Add(name, totalMeasurments);
        }
    }
}
