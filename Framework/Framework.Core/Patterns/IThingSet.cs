// ============================================================================
// Project: Framework
// Name/Class: IThingSet
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Set of things. Contract.
// ============================================================================

using System.Collections.Generic;

namespace Framework.Core.Patterns
{
    public interface IThingSet : IList<IThing>, IXmlReady { }
}
