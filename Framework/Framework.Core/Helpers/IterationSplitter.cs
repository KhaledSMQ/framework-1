// ============================================================================
// Project: Framework
// Name/Class: IndexSpan
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Class used to split indexes into iteration spans.
// ============================================================================

using System;
using System.Collections.Generic;

namespace Framework.Core.Helpers
{
    public class IterationSplitter
    {
        //
        // Calculate how many items there will be in an iteration.
        //

        public static int CalculateItemsPerIteration(double totalCount, int numberOfIterations)
        {
            double itemsPerColumnD = totalCount / numberOfIterations;
            int itemsPerColumn = Convert.ToInt32(Math.Ceiling(itemsPerColumnD));
            return itemsPerColumn;
        }

        //
        // Splits the iteratons into parts(spans).
        //                

        public static List<IndexSpan> SplitIterations(int totalCount, int numberOfIterations)
        {
            int itemsPerIteration = CalculateItemsPerIteration(totalCount, numberOfIterations);
            return Split(totalCount, itemsPerIteration);
        }

        //
        // Splits the iteratons into parts(spans).
        //

        public static List<IndexSpan> Split(int totalCount, int itemsPerIteration)
        {
            //Requirement.IsTrue(totalCount != 0, "Invalid indexes span specified.");
            if (totalCount == 0)
            {
                return new List<IndexSpan>();
            }

            List<IndexSpan> iterationSpans = new List<IndexSpan>();

            // 
            // Handle case where total = items per iteration.
            //

            if (totalCount == itemsPerIteration)
            {
                iterationSpans.Add(new IndexSpan(0, itemsPerIteration));
                return iterationSpans;
            }

            // 
            // Handle case where total < items per iteration
            //

            if (totalCount < itemsPerIteration)
            {
                iterationSpans.Add(new IndexSpan(0, totalCount));
                return iterationSpans;
            }

            // 
            // Now create the iterations.
            //

            int nextStartingIndex = 0;
            int count = itemsPerIteration;
            int totalCountProcessed = 0;
            int leftOver = 0;

            while (totalCountProcessed < totalCount)
            {
                IndexSpan span = new IndexSpan(nextStartingIndex, count);
                iterationSpans.Add(span);

                // 
                // Used to break the loop. We've finished all the items.
                //

                totalCountProcessed += count;

                // 
                // Now calculate the next starting index.
                //

                nextStartingIndex = span.EndIndex + 1;

                // 
                // Now determine left over items
                //

                leftOver = totalCount - totalCountProcessed;

                if (leftOver >= itemsPerIteration)
                {
                    count = itemsPerIteration;
                }
                else
                {
                    count = leftOver;
                }
            }

            return iterationSpans;
        }
    }
}
