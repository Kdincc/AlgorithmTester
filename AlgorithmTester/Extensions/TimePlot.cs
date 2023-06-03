using ScottPlot;

namespace AlgorithmTester
{
    public static class TimePlot
    {
        public static void CreatePlot(this WpfPlot plot, double[] values, string[] names, string yLabelName, string xLabelName)
        {
            double[] positions = new double[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                positions[i] = i;
            }

            var bar = plot.Plot.AddBar(values, positions);
            bar.ShowValuesAboveBars = true;
            plot.Plot.XTicks(positions, names);
            plot.Plot.YLabel(yLabelName);
            plot.Plot.XLabel(xLabelName);
            plot.Plot.SetAxisLimits(yMin: 0);


            plot.Plot.SaveFig("bar_labels.png");

            plot.Refresh();

        }
    }
}
