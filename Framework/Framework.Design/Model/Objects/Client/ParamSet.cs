// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 18/Jul/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Design.Model.Objects.Client
{
    public class ParamSet<TUser> : SortedDictionary<Id, Param<TUser>> { }
}
