using System;
using System.Collections.Generic;

namespace AlgorithmTester
{
    public interface IMeasurmentsManager
    {
        Dictionary<string, double> Results { get; }

        void AddResult(string name, Action<int[]> alg, int[] array);
    }
}
