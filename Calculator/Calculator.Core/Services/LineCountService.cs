namespace Calculator.Core.Services
{
    public interface ILineCountService
    {
        long LineCount { get; }
        void IncrementLineCount();
    }

    /// <summary>
    /// Simple data service to keep track of the line number
    /// for use in error reporting.
    /// </summary>
    public class LineCountService : ILineCountService
    {
        public long LineCount { get; private set; }

        public void IncrementLineCount()
        {
            LineCount++;
        }
    }
}
