using System;
using System.IO;
using System.Threading.Tasks;
using Calculator.Core;
using Calculator.Core.FileReader;

namespace Calculator.Ui
{
    public class CalculationController
    {
        private readonly ICalculator _calculator;
        private readonly ICalculationsFileReader _calculationsFileReader;

        public CalculationController(ICalculator calculator,
                                     ICalculationsFileReader calculationsFileReader)
        {
            _calculator = calculator;
            _calculationsFileReader = calculationsFileReader;
        }
        
        public async Task RunAsync()
        {
            var fileInfo = GetFilePathFromUser();
            var orderedOperations = _calculationsFileReader.GetOrderedOperations(fileInfo);
            var result = await _calculator.CalculateResultAsync(orderedOperations);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine("Press any key to quit");
            Console.ReadLine();
        }

        private FileInfo GetFilePathFromUser()
        {
            FileInfo fileInfo = null;
            
            while (fileInfo == null)
            {
                Console.WriteLine("Please enter the full path and file name of the Calculations input file:");
                var path = Console.ReadLine();

                if (path != null && File.Exists(path))
                {
                    fileInfo = new FileInfo(path);
                }
                else
                {
                    Console.WriteLine("The file could not be found. Please try again.");
                }
            }

            return fileInfo;
        }
    }
}