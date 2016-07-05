// ============================================================================
// Project: Framework
// Name/Class: IThingSet
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Set of things. Contract.
// ============================================================================

using System.Collections.Generic;

namespace Framework.Core.Patterns
{
    public interface IThingSet : IList<IThing>, IXmlReady { }
}
