// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using System.Collections.Generic;

namespace Framework.Packages.Model.Objects
{
    public class DependencySet : List<Dependency>, ICollection<Dependency>, IList<Dependency>
    {
        //
        // CONSTRUCTORS
        //

        public DependencySet() : base() { }

        public DependencySet(IEnumerable<Dependency> items) : base(items) { }
    }
}
