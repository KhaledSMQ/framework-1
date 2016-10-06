// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using System.Collections.Generic;
using Framework.Core.Extensions;

namespace Framework.Packages.Model.Objects
{
    public class PackageSet : List<Package>
    {
        //
        // PROPERTIES
        // 

        public DocumentSet Documents { get { return GetDocumentSet(); } }

        public FileSet Files { get { return GetFileSet(); } }

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
