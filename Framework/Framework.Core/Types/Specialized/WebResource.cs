// ============================================================================
// Project: Framework
// Name/Class: WebResource
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Web resource wrapper class.
// ============================================================================                    

namespace Framework.Types.Specialized
{
    public class WebResource
    {
        //
        // Type of resource.
        //

        public enum TypeOfResource
        {
            UNDEFINED,
            STYLE,
            SCRIPT
        };

        //
        // Source of resource, several types of sources can be defined
        // a remote file, an embedded resource or an inline resource.
        //

        public enum TypeOfSource
        {
            UNDEFINED,
            REMOTE,
            INLINE
        }

        //
        // PROPERTIES
        //

        public TypeOfResource Type { get; set; }
        public TypeOfSource Source { get; set; }
        public string MimeType { get; set; }
        public string Media { get; set; }
        public string Value { get; set; }

        //
        // CONSTRUCTORS
        //

        public WebResource() : this(TypeOfResource.UNDEFINED, TypeOfSource.UNDEFINED, string.Empty) { }

        public WebResource(TypeOfResource type, TypeOfSource source, string value) : this(type, source, value, string.Empty) { }

        public WebResource(TypeOfResource type, TypeOfSource source, string value, string media)
        {
            Type = type;
            Source = source;
            Value = value;
            MimeType = string.Empty;
            Media = media;
        }

        //
        // STATIC - HELPER METHODS - SCRIPTS
        //

        public static WebResource ScriptInline(string value)
        {
            return new WebResource(TypeOfResource.SCRIPT, TypeOfSource.INLINE, value);
        }

        public static WebResource ScriptRemote(string url)
        {
            return new WebResource(TypeOfResource.SCRIPT, TypeOfSource.REMOTE, url);
        }

        //
        // STATIC - HELPER METHODS - STYLES
        //

        public static WebResource StyleInline(string value)
        {
            return new WebResource(TypeOfResource.STYLE, TypeOfSource.INLINE, value);
        }

        public static WebResource StyleRemote(string url)
        {
            return new WebResource(TypeOfResource.STYLE, TypeOfSource.REMOTE, url);
        }
    }
}
