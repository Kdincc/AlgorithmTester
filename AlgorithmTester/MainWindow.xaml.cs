using Microsoft.Extensions.DependencyInjection;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AlgorithmTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int SLIDER_VALUE_MULTIPLIER = 100;
        private readonly ISorter sorter;
        private readonly IExecuteTimeManager manager;

        public MainWindow()
        {
            InitializeComponent();

            var services = new ServiceCollection().RegisterServices();

            using var provider = services.BuildServiceProvider();

            sorter = provider.GetRequiredService<ISorter>();
            manager = provider.GetRequiredService<IExecuteTimeManager>();
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

            ResultPlot.Plot.Clear();

            if (InputBox.IsEnabled)
            {
                array = InputBox.GetArray();
            }
            else
            {
                Random random = new Random();
                int size = Convert.ToInt32(SizeSlider.Value * SLIDER_VALUE_MULTIPLIER);

                array = new int[size];

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = random.Next(0, 1001);
                }
            }

            if ((bool)InsertionSortCheckBox.IsChecked)
            {
                manager.AddResult(AlgorithmNames.Insertion.ToString(), new Action<int[]>(sorter.InsertionSort), array);
            }

            if ((bool)SelectionSortCheckBox.IsChecked)
            {
                manager.AddResult(AlgorithmNames.Selection.ToString(), new Action<int[]>(sorter.SelectionSort), array);
            }

            if ((bool)ShellSortCheckBox.IsChecked)
            {
                manager.AddResult(AlgorithmNames.Shell.ToString(), new Action<int[]>(sorter.ShellSort), array);
            }

            if ((bool)QuickSortCheckBox.IsChecked)
            {
                manager.AddResult(AlgorithmNames.Quick.ToString(), new Action<int[]>(sorter.QuickSort), array);
            }

            if ((bool)MergeSortCheckBox.IsChecked)
            {
                manager.AddResult(AlgorithmNames.Merge.ToString(), new Action<int[]>(sorter.MergeSort), array);
            }

            var values = manager.Results.Values.ToArray();
            var names = manager.Results.Keys.ToArray();

            ResultPlot.CreatePlot(values, names);

            manager.Results.Clear();
           
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
    }
}
