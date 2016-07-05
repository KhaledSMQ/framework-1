// ============================================================================
// Project: Framework
// Name/Class: IXmlReadyParameterized
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that implement parse and unparse from Xml.
//              Specifying the root namespace and name.
// ============================================================================                    

using System.Xml.Linq;

namespace Framework.Core.Patterns
{
    public interface IXmlReadyParameterized
    {
        //
        // Parse from a Xml element the item specification. This method will 
        // take a Xml element and parse it, building the item properties. This
        // should clear all current properties, if they exist.
        //

        void ParseFromXml(XElement elm, string ns, string name);

        //
        // Unparse the item to a Xml element specification. This method will
        // generate a Xml from this items properties.
        //

        XElement UnparseToXml(string ns, string name);
    }
}
