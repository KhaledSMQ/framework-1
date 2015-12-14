// ============================================================================
// Project: Framework
// Name/Class: IndexSpan
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Represents a set of indexes which will be iterated on.
// ============================================================================

namespace Framework.Core.Helpers
{
    public class IndexSpan
    {
        //
        // CONSTRUCTORS
        //

        public IndexSpan(int start, int count)
        {
            StartIndex = start;
            Count = count;
        }

        //
        // The start index.
        //

        public int StartIndex;

        //
        // Number of items represented in this iteration.
        //

        public int Count;

        //
        // The ending index, as calculated using the startIndex and count.
        //

        public int EndIndex
        {
            get { return (StartIndex + Count) - 1; }
        }
    }
}
