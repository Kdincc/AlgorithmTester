namespace AlgorithmTester
{
    public interface ISorter
    {
        void InsertionSort(int[] array);

        void QuickSort(int[] array);

        void ShellSort(int[] array);

        void SelectionSort(int[] array);

        void MergeSort(int[] array);

        void HeapSort(int[] array);

        void BubbleSort(int[] array);

        void CountingSort(int[] array);

        void RadixSort(int[] array);
    }
}
