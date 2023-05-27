using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmTester
{
    public static class DependancyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services) 
        {
            services.AddTransient<ISorter, Sorter>();
            services.AddTransient<ITimeHandler, SortTimeCheker>();
            services.AddTransient<IExecuteTimeManager, ExecuteTimeManager>();

            return services;
        }
    }
}
