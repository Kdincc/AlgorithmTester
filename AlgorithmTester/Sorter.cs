using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace AlgorithmTester
{
    public class Sorter : ISorter
    {
        public void InsertionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }

        public void SelectionSort(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }

        #region MergeSort
        public void MergeSort(int[] array)
        {
            int left = 0;
            int right = array.Length - 1;

            MergeSortRecursive(array, left, right);
        }

        private void MergeSortRecursive(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSortRecursive(array, left, middle);
                MergeSortRecursive(array, middle + 1, right);

                Merge(array, left, middle, right);
            }
        }

        private void Merge(int[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            Array.Copy(array, left, leftArray, 0, n1);
            Array.Copy(array, middle + 1, rightArray, 0, n2);

            int i = 0, j = 0;
            int k = left;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
        }

        #endregion

        #region QuickSort

        public void QuickSort(int[] arr)
        {
            RecQuickSort(arr, 0, arr.Length - 1);
        }

        private void RecQuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                int pivotIndex = Partition(arr, low, high);
                RecQuickSort(arr, low, pivotIndex - 1);
                RecQuickSort(arr, pivotIndex + 1, high);
            }
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);
            return i + 1;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        #endregion

        public void ShellSort(int[] array)
        {
            int n = array.Length;
            int gap = n / 2;

            while (gap > 0)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j = i;

                    while (j >= gap && array[j - gap] > temp)
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }

                    array[j] = temp;
                }

                gap /= 2;
            }
        }

        #region RadixSort

        // Метод для поиска максимального элемента в массиве
        private int FindMax(int[] array)
        {
            int max = array[0];
            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        // Метод для выполнения сортировки по разрядам
        public void RadixSort(int[] array)
        {
            int max = FindMax(array);

            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSort(array, exp);
            }
        }

        // Метод для выполнения сортировки подсчетом
        private void CountingSort(int[] array, int exp)
        {
            int n = array.Length;
            int[] output = new int[n];
            int[] count = new int[10];
            Array.Fill(count, 0);

            for (int i = 0; i < n; i++)
            {
                count[(array[i] / exp) % 10]++;
            }

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(array[i] / exp) % 10] - 1] = array[i];
                count[(array[i] / exp) % 10]--;
            }

            for (int i = 0; i < n; i++)
            {
                array[i] = output[i];
            }
        }

        #endregion

        public void CountingSort(int[] array)
        {
            int n = array.Length;
            int[] output = new int[n];

            // Находим максимальное значение в массиве
            int max = array[0];
            for (int i = 1; i < n; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            // Создаем вспомогательный массив для подсчета количества элементов
            int[] count = new int[max + 1];
            Array.Fill(count, 0);

            // Подсчитываем количество вхождений каждого элемента
            for (int i = 0; i < n; i++)
            {
                count[array[i]]++;
            }

            // Модифицируем вспомогательный массив, чтобы он содержал позиции элементов в отсортированном порядке
            for (int i = 1; i <= max; i++)
            {
                count[i] += count[i - 1];
            }

            // Помещаем элементы в отсортированный массив в соответствии с их позициями из вспомогательного массива
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[array[i]] - 1] = array[i];
                count[array[i]]--;
            }

            // Копируем отсортированный массив обратно в исходный массив
            for (int i = 0; i < n; i++)
            {
                array[i] = output[i];
            }
        }

        public void BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        #region HeapSort

        // O( n log(n) )
        public void HeapSort(int[] array)
        {
            int n = array.Length;

            // Построение кучи (Heapify)
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            }

            // Извлечение элементов из кучи один за другим
            for (int i = n - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец массива
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                // Вызываем Heapify на уменьшенной куче
                Heapify(array, i, 0);
            }
        }

        // Метод для преобразования поддерева с корнем i в кучу
        private static void Heapify(int[] array, int n, int i)
        {
            int largest = i; // Инициализируем наибольший элемент как корень
            int leftChild = 2 * i + 1; // Левый потомок
            int rightChild = 2 * i + 2; // Правый потомок

            // Если левый потомок больше корня
            if (leftChild < n && array[leftChild] > array[largest])
            {
                largest = leftChild;
            }

            // Если правый потомок больше текущего наибольшего элемента
            if (rightChild < n && array[rightChild] > array[largest])
            {
                largest = rightChild;
            }

            // Если наибольший элемент не является корневым
            if (largest != i)
            {
                // Обмен значениями
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                // Рекурсивно Heapify на затронутой поддереве
                Heapify(array, n, largest);
            }
        }

        #endregion
    }
}
