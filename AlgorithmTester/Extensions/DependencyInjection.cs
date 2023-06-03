using Microsoft.Extensions.DependencyInjection;

namespace AlgorithmTester
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ISorter, Sorter>();
            services.AddTransient<IMeasurmentsHandler, SortTimeCheker>();
            services.AddTransient<IMeasurmentsManager, ExecuteTimeManager>();

            return services;
        }
    }
}
