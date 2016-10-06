// ============================================================================
// Project: Framework
// Name/Class: Table
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Table datatype.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Core.Collections.Specialized
{
    public class ConfigMap : SortedDictionary<string, Setting>, IConfigMap { }
}
