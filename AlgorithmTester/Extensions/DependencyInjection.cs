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
        public static IServiceCollection RegisterCoreServices(this IServiceCollection services) 
        {
            services.AddTransient<ISorter, Sorter>();
            services.AddTransient<IMeasurmentsHandler, SortTimeCheker>();
            services.AddTransient<IMeasurmentsManager, ExecuteTimeManager>();

            return services;
        }
    }
}
