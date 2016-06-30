// ============================================================================
// Project: Framework
// Name/Class: IXmlDocReady
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that implement parse and unparse from Xml.
// ============================================================================                    

using System.Xml.Linq;

namespace Framework.Core.Patterns
{
    public interface IXmlDocReady
    {
        //
        // Parse from a Xml element the item specification. This method will 
        // take a Xml element and parse it, building the item properties. This
        // should clear all current properties, if they exist.
        //

        void ParseFromXmlDoc(XDocument doc);

        //
        // Unparse the item to a Xml element specification. This method will
        // generate a Xml from this items properties.
        //

        XDocument UnparseToXmlDoc();
    }
}
