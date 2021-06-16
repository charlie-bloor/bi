using System.Reflection;
using Calculator.Core;
using Calculator.Core.Operators;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Ui.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUiServices(this IServiceCollection services)
        {
            services.AddTransient<CalculationController, CalculationController>();
            return services;
        }
    }
}
