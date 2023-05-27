using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace AlgorithmTester
{
    public interface ITimeHandler
    {
        double GetExecutionTime(Action<int[]> algorithm, int[] array);
    }
}
