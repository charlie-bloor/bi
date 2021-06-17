namespace Calculator.Core.Services
{
    /// <summary>
    /// Simple shared data service to keep track of the line number.
    /// Ror use in error reporting.
    /// </summary>
    public interface ILineCounter
    {
        long LineCount { get; }
        void IncrementLineCount();
    }

    public class LineCounter : ILineCounter
    {
        public long LineCount { get; private set; }

        public void IncrementLineCount()
        {
            LineCount++;
        }
    }
}
