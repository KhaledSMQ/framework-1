// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 25/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Packages.Model
{
    public class Package : IID<string>
    {
        //
        // PROPERTIES
        //

        public string ID { get; set; }

        public string Description { get; set; }

        public string BaseVirtualPath { get; set; }

        public string BasePhysicalPath { get; set; }

        public DocumentSet Documents { get; set; }

        public DependencySet Dependencies { get; set; }

        //
        // COMPUTED PROPERTIES
        // 

        public FileSet Files { get { return GetFileSet(); } }

        //
        // CONSTRUCTORS
        //

        public Package()
        {
            ID = string.Empty;
            Description = string.Empty;
            BaseVirtualPath = string.Empty;
            BasePhysicalPath = string.Empty;
            Documents = null;
            Dependencies = null;
        }

        //
        // Return the list of all files found in this package.
        // Use the document set order.
        //

        public FileSet GetFileSet()
        {
            return null == Documents ? new FileSet() : Documents.Files;
        }
    }
}
