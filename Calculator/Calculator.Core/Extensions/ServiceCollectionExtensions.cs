using System.Reflection;
using Calculator.Core.Converters;
using Calculator.Core.Operators;
using Calculator.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            AddSingletonServices(services);
            AddTransientServices(services);
            return services;
        }

        private static void AddSingletonServices(IServiceCollection services)
        {
            services.AddSingleton<ILineCounter, LineCounter>();
        }

        private static void AddTransientServices(IServiceCollection services)
        {
            services.AddTransient<ICalculator, Services.Calculator>();
            services.AddTransient<IFileParser, FileParser>();
            services.AddTransient<IStringToOperationConverter, StringToOperationConverter>();
            services.AddTransient<IFileParser, FileParser>();
            services.AddTransient<IStringToOperandConverter, StringToOperandConverter>();
            services.AddTransient<IStringToOperationTypeConverter, StringToOperationTypeConverter>();

            var executingAssembly = Assembly.GetExecutingAssembly();

            services.Scan(scan =>
            {
                scan.FromAssemblies(executingAssembly)
                    .AddClasses(classes => classes.AssignableToAny(typeof(IOperator)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }
    }
}
