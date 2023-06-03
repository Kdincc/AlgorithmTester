using AlgorithmTester.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AlgorithmTester
{
    public partial class MainWindow : Window
    {
        private const int SLIDER_VALUE_MULTIPLIER = 100;
        private readonly ISorter sorter;
        private readonly IMeasurmentsManager timeManager;
        public MainWindow()
        {
            InitializeComponent();

            var provider = new ServiceCollection().RegisterCoreServices().BuildServiceProvider();

            sorter = provider.GetRequiredService<ISorter>();
            timeManager = provider.GetRequiredService<IMeasurmentsManager>();

            
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            ((Slider)sender).SelectionEnd = e.NewValue;

            int value = Convert.ToInt32(SizeSlider.Value) * SLIDER_VALUE_MULTIPLIER;
            ArraySizeBox.Text = value.ToString() + " size";

            if (SizeSlider.Value != 0)
            {
                InputBox.IsEnabled = false;
                return;
            }

            InputBox.IsEnabled = true;
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            int[] array = new int[0];

            TimePlot.Plot.Clear();

            if (InputBox.IsEnabled)
            {
                if (InputBox.Text.IsArrayString())
                {
                    array = InputBox.GetArray();
                }
                else
                {
                    MessageBox.Show ("Incorrect input! Correct input format is: 1,2,3,4,5,6...");
                    return;
                }
            }
            else
            {
                Random random = new Random();
                int size = Convert.ToInt32(SizeSlider.Value) * SLIDER_VALUE_MULTIPLIER;

                array = new int[size];

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = random.Next(0, 100001);
                }
            }

            BoxChecking(array);

            var values = timeManager.Results.Values.ToArray();
            var names = timeManager.Results.Keys.ToArray();

            TimePlot.CreatePlot(values, names, "Time in ms", "Algorithms");
        }

        private void InputBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(InputBox.Text))
            {
                SizeSlider.IsEnabled = false;
                return;
            }

            SizeSlider.IsEnabled = true;
        }

        private void BoxChecking(int[] array)
        {

            if ((bool)BubbleSortCheckBox.IsChecked)
            {
                timeManager.AddResult(AlgorithmNames.Bubble.ToString(), new Action<int[]>(sorter.BubbleSort), array);
            }

            if ((bool)InsertionSortCheckBox.IsChecked)
            {
                timeManager.AddResult(AlgorithmNames.Insertion.ToString(), new Action<int[]>(sorter.InsertionSort), array);
            }

            if ((bool)SelectionSortCheckBox.IsChecked)
            {
                timeManager.AddResult(AlgorithmNames.Selection.ToString(), new Action<int[]>(sorter.SelectionSort), array);
            }

            if ((bool)ShellSortCheckBox.IsChecked)
            {
                timeManager.AddResult(AlgorithmNames.Shell.ToString(), new Action<int[]>(sorter.ShellSort), array);
            }

            if ((bool)MergeSortCheckBox.IsChecked)
            {
                timeManager.AddResult(AlgorithmNames.Merge.ToString(), new Action<int[]>(sorter.MergeSort), array);
            }

            if ((bool)QuickSortCheckBox.IsChecked)
            {
                timeManager.AddResult(AlgorithmNames.Quick.ToString(), new Action<int[]>(sorter.QuickSort), array);
            }

            if ((bool)CountingSortCheckBox.IsChecked)
            {
                timeManager.AddResult(AlgorithmNames.Counting.ToString(), new Action<int[]>(sorter.CountingSort), array);
            }

            if ((bool)RadixSortCheckBox.IsChecked)
            {
                timeManager.AddResult(AlgorithmNames.Radix.ToString(), new Action<int[]>(sorter.RadixSort), array);
            }

            if ((bool)HeapSortCheckBox.IsChecked)
            {
                timeManager.AddResult(AlgorithmNames.Heap.ToString(), new Action<int[]>(sorter.HeapSort), array);
            }
        }
    }
}
