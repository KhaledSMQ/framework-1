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
    public class File : IID<string>
    {
        //
        // PROPERTIES
        //

        public string ID { get; set; }

        public string Name { get; set; }

        public string RelativePath { get; set; }

        public string RelativeUrl { get; set; }

        public string AbsoluteUrl { get; set; }

        public string MimeType { get; set; }

        //
        // CONSTRUCTORS
        //

        public File()
        {
            ID = string.Empty;
            Name = string.Empty;
            RelativePath = string.Empty;
            RelativeUrl = string.Empty;
            AbsoluteUrl = string.Empty;
            MimeType = string.Empty;
        }
    }
}
