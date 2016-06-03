﻿// ============================================================================
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
    public class DocumentSet : List<Document>, ICollection<Document>, IList<Document>
    {
        //
        // PROPERTIES
        // 

        public FileSet Files { get { return GetFileSet(); } }

        //
        // CONSTRUCTORS
        //

        public DocumentSet() : base() { }

        public DocumentSet(IEnumerable<Document> items) : base(items) { }

        //
        // Return the list of all files found in this package.
        // Use the document set order.
        //

        public FileSet GetFileSet()
        {
            FileSet set = new FileSet();
            this.Apply(doc => { set.AddRange(doc.Files); });
            return set;
        }
    }
}
