using System;

namespace AlgorithmTester
{
    public interface IMeasurmentsHandler
    {
        double GetMeasurments(Action<int[]> algorithm, int[] array);
    }
}
