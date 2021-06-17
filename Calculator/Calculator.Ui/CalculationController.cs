using System;
using System.IO;
using System.Threading.Tasks;
using Calculator.Core;
using Calculator.Core.Exceptions;
using Calculator.Core.FileReader;
using Calculator.Core.Services;

namespace Calculator.Ui
{
    public class CalculationController
    {
        private readonly ICalculator _calculator;
        private readonly ICalculationsFileReader _calculationsFileReader;
        private readonly ILineCountService _lineCountService;

        public CalculationController(ICalculator calculator,
                                     ICalculationsFileReader calculationsFileReader,
                                     ILineCountService lineCountService)
        {
            _calculator = calculator;
            _calculationsFileReader = calculationsFileReader;
            _lineCountService = lineCountService;
        }
        
        public async Task RunAsync()
        {
            try
            {
                var fileInfo = GetFilePathFromUser();
                var orderedOperations = _calculationsFileReader.GetOrderedOperations(fileInfo);
                var result = await _calculator.CalculateResultAsync(orderedOperations);
                Console.WriteLine(result);
                Console.WriteLine();
                Console.WriteLine("Press any key to quit");
                Console.ReadLine();
            }
            catch (InvalidInputFileException e)
            {
                Console.WriteLine("Sorry, but there was a problem with the input file.");

                if (_lineCountService.LineCount != default)
                {
                    Console.WriteLine($"The problem occurred at line {_lineCountService.LineCount}.");
                }

                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry, but there was a problem.");
                Console.WriteLine(e.Message);
            }
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