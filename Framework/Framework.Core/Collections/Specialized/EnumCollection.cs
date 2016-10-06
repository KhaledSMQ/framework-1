// ============================================================================
// Project: Framework
// Name/Class: EnumCollection
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Collecion of enumeration values.
// ============================================================================

using System.Collections.ObjectModel;
using Framework.Core.Types.Specialized;

namespace Framework.Core.Collections.Specialized
{
    public class EnumCollection<T> : KeyedCollection<string, EnumValue<T>> where T : struct
    {
        protected override string GetKeyForItem(EnumValue<T> item)
        {
            return item.Name;
        }
    }
}