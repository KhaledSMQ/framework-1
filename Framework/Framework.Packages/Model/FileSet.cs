// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 25/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using System.Collections.Generic;
using Framework.Core.Extensions;

namespace Framework.Packages.Model
{
    public class FileSet : List<File>, ICollection<File>, IList<File>
    {
        //
        // PROPERTIES
        //

        public UrlSet AbsoluteUrls { get { return GetAbsoluteUrlSet(); } }

        //
        // CONSTRUCTORS
        //

        public FileSet() : base() { }

        public FileSet(IEnumerable<File> items) : base(items) { }

        //
        // Get the list of absolute urls from the file set.
        //

        public UrlSet GetAbsoluteUrlSet()
        {
            UrlSet set = new UrlSet();
            this.Apply(file => { set.Add(file.AbsoluteUrl); });
            return set;
        }
    }
}
