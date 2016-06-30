// ============================================================================
// Project: Framework
// Name/Class: EnumerableHelper
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Helper functions for enumerations.
// ============================================================================

using System;

namespace Framework.Core
{
    public class EnumerableHelper
    {
        //
        // Calls the action by supplying the start and end index.
        //

        public static void ForEachByCols(int itemCount, int cols, Action<int, int> action)
        {
            if (itemCount > 0)
            {
                if (itemCount <= cols)
                {
                    action(0, itemCount - 1);
                }
                else
                {
                    int startNdx = 0;

                    while (startNdx < itemCount)
                    {
                        //
                        // 1. startNdx = 0 .. endNdx = 2
                        // 2. startNdx = 3 .. endNdx = 5
                        //

                        int endNdx = startNdx + (cols - 1);

                        if (endNdx >= itemCount)
                        {
                            endNdx = itemCount - 1;
                        }

                        action(startNdx, endNdx);
                        startNdx = endNdx + 1;
                    }
                }
            }
        }
    }
}
