using System.Threading.Tasks;
using Calculator.Core.Extensions;
using Calculator.Ui.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Ui
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddCoreServices()
                .AddUiServices()
                .BuildServiceProvider();

            //configure console logging
            // serviceProvider
            //     .GetService<ILoggerFactory>()
            //     .AddConsole(LogLevel.Debug);
            //
            // var logger = serviceProvider.GetRequiredService<ILoggerFactory>()
            //     .CreateLogger<Program>();
            // logger.LogDebug("Starting application");

            var calculationController = serviceProvider.GetRequiredService<CalculationController>();
            await calculationController.RunAsync();
        }
    }
}