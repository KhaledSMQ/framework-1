// ============================================================================
// Project: Framework
// Name/Class: IXmlReady
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that implement parse and unparse from Xml.
// ============================================================================                    

using System.Xml.Linq;

namespace Framework.Core.Patterns
{
    public interface IXmlReady
    {
        //
        // Parse from a Xml element the item specification. This method will 
        // take a Xml element and parse it, building the item properties. This
        // should clear all current properties, if they exist.
        //

        void ParseFromXml(XElement elm);

        //
        // Unparse the item to a Xml element specification. This method will
        // generate a Xml from this items properties.
        //

        XElement UnparseToXml();
    }
}
