using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTester
{
    public interface ISorter
    {
        void InsertionSort(int[] array);

        void QuickSort(int[] array);

        void ShellSort(int[] array);

        void SelectionSort(int[] array);

        void MergeSort(int[] array);
    }
}
