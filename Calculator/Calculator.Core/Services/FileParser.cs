using System.Collections.Generic;
using System.IO;
using Calculator.Core.Converters;
using Calculator.Core.Exceptions;

namespace Calculator.Core.Services
{
    /// <summary>
    /// Parses the input file and returns the operations to perform,
    /// in order, starting with the "apply" instruction.
    /// </summary>
    public interface IFileParser
    {
        /// <summary>
        /// Parse the input file and return the operations to perform,
        /// in order, starting with the "apply" instruction.
        /// </summary>
        IAsyncEnumerable<Operation> GetOrderedOperations(FileInfo fileInfo);
    }

    public class FileParser : IFileParser
    {
        // TODO: we would want to make this cancellable if we were processing very large files.

        private readonly IStringToOperationConverter _stringToOperationConverter;

        public FileParser(IStringToOperationConverter stringToOperationConverter)
        {
            _stringToOperationConverter = stringToOperationConverter;
        }

        // TODO: make cancellable
        public async IAsyncEnumerable<Operation> GetOrderedOperations(FileInfo fileInfo)
        {
            // Return the last operation first
            var lastLineOfFile = GetLastLineOfFile(fileInfo);
            var operation = _stringToOperationConverter.Convert(lastLineOfFile);

            if (operation.OperationType != OperationType.Apply)
            {
                throw new InvalidInputFileException("The last line of the file was not valid.");
            }

            yield return operation;

            string nextLine;

            using var streamReader = File.OpenText(fileInfo.FullName);

            while ((nextLine = await streamReader.ReadLineAsync()) != null)
            {
                operation = _stringToOperationConverter.Convert(nextLine);

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
                throw new InvalidInputFileException("The file was found to be empty.");
            }

            // Start at end of file.
            stream.Position = stream.Length - 1;

            // While the start of the file has not been reached, read bytes backwards until an '\n' byte is encountered.
            while (stream.Position > 0)
            {
                stream.Position--;
                var byteFromFile = stream.ReadByte();

                if (byteFromFile < 0)
                {
                    throw new InvalidInputFileException("The file may have been written to during processing.");
                }

                if (byteFromFile == '\n')
                {
                    // The new line was found. The stream position is 1 after the '\n' character.
                    break;
                }

                stream.Position--;
            }

            // The stream will be positioned immediately after the '\n' char, or position zero if no '\n' character.
            var bytes = new BinaryReader(stream).ReadBytes((int) (stream.Length - stream.Position));

            // TODO: we might need to handle other encodings.
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}