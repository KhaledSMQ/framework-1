// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using System.Collections.Generic;
using Framework.Core.Extensions;

namespace Framework.Packages.Model
{
    public class PackageSet : List<Package>, ICollection<Package>, IList<Package>
    {
        //
        // PROPERTIES
        // 

        public DocumentSet Documents { get { return GetDocumentSet(); } }

        public FileSet Files { get { return GetFileSet(); } }

        //
        // CONSTRUCTORS
        //

        public PackageSet() : base() { }

        //
        // Return the list of all documents found in this package.
        // Use the document set order.
        //

        public DocumentSet GetDocumentSet()
        {
            DocumentSet set = new DocumentSet();
            this.Apply(package => { set.AddRange(package.Documents); });
            return set;
        }

        //
        // Return the list of all files found in this package.
        // Use the document set order.
        //

        public FileSet GetFileSet()
        {
            FileSet set = new FileSet();
            this.Apply(package => { set.AddRange(package.Files); });
            return set;
        }
    }
}
