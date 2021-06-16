using System;
using System.Collections.Generic;
using System.IO;
using Calculator.Core.Converters;

namespace Calculator.Core.FileReader
{
    public interface ICalculationsFileReader
    {
        IAsyncEnumerable<Operation> GetOrderedOperations(FileInfo fileInfo);
    }

    public class CalculationsFileReader : ICalculationsFileReader
    {
        private readonly IOperationFactory _operationFactory;

        public CalculationsFileReader(IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }
        
        // TODO: make cancellable
        public async IAsyncEnumerable<Operation> GetOrderedOperations(FileInfo fileInfo)
        {
            // Handle file problems
            // yield return convert GetLastLine
            // for each remaining line, yield return
            
            string nextLine;
            var lineCounter = 1;  // TODO: use

            using var streamReader = File.OpenText(fileInfo.FullName);
            
            while ((nextLine = await streamReader.ReadLineAsync()) != null)
            {
                var operation = _operationFactory.Create(nextLine);
                lineCounter++;
                yield return operation;
            }
        }

        private string GetLastLineOfFile()
        {
            // TODO: implement:
            // Read last n bytes of file into string
            // Split at line break
            // Return last of split
            throw new NotImplementedException();
        }
    }
}