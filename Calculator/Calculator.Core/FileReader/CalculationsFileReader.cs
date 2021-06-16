using System.Collections.Generic;
using System.IO;

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

            // Return the last instruction first
            var lastLineOfFile = GetLastLineOfFile(fileInfo);
            var operation = _operationFactory.Create(lastLineOfFile);

            if (operation.OperationType != OperationType.Apply)
            {
                // TODO: throw
            }

            yield return operation;

            string nextLine;
            var lineCounter = 1; // TODO: use

            using var streamReader = File.OpenText(fileInfo.FullName);

            while ((nextLine = await streamReader.ReadLineAsync()) != null)
            {
                operation = _operationFactory.Create(nextLine);
                lineCounter++;

                if (operation.OperationType == OperationType.Apply)
                {
                    // The apply instruction at the end of the file has been reached,
                    // which has already been processed. Stop processing.
                    break;
                }

                yield return operation;
            }
        }

        private string GetLastLineOfFile(FileSystemInfo fileInfo)
        {
            using Stream stream = File.OpenRead(fileInfo.FullName);

            if (stream.Length == 0)
            {
                // The file is empty
                return null;
            }

            // Start at end of file
            stream.Position = stream.Length - 1;

            // While we have not yet reached start of file, read bytes backwards until '\n' byte is encountered
            while (stream.Position > 0)
            {
                stream.Position--;
                var byteFromFile = stream.ReadByte();

                if (byteFromFile < 0)
                {
                    // Someone must have emptied the file while it was being read
                    throw new IOException("Error reading from file at " + fileInfo.FullName);
                }

                if (byteFromFile == '\n')
                {
                    // The new line was found; stream.Position is 1 after the '\n' char
                    break;
                }

                stream.Position--;
            }

            // stream.Position will is immediately after the '\n' char or position 0 if no '\n' char
            byte[] bytes = new BinaryReader(stream).ReadBytes((int) (stream.Length - stream.Position));

            // TODO: handle non-ASCII encodings?
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}