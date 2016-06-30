// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using System.Collections.Generic;

namespace Framework.Packages.Model
{
    public class UrlSet : List<string>, ICollection<string>, IList<string>
    {
        //
        // CONSTRUCTORS
        //

        public UrlSet() : base() { }

        public UrlSet(IEnumerable<string> items) : base(items) { }
    }
}
