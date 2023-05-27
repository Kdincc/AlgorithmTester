using ScottPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTester
{
    public static class TimePlot
    {
        public static void CreateTimePlot(this WpfPlot plot, double[] values, string[] names)
        {
            double[] positions = new double[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                positions[i] = i;
            }

            var bar = plot.Plot.AddBar(values, positions);
            bar.ShowValuesAboveBars= true;
            plot.Plot.XTicks(positions, names);
            plot.Plot.SetAxisLimits(yMin: 0);


            plot.Plot.SaveFig("bar_labels.png");

            plot.Refresh();
            
        }
    }
}
