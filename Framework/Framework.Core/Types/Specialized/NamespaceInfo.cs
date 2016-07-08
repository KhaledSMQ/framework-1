// ============================================================================
// Project: Framework
// Name/Class: NamespaceInfo
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Namespace information.
// ============================================================================

using System.Collections.Generic;
using Framework.Core.Extensions;

namespace Framework.Core.Types.Specialized
{
    public class NamespaceInfo : AssemblyInfo
    {
        //
        // PROPERTIES
        //

        public string Namespace { get; set; }

        //
        // Parse from string the namespace information
        // object.
        //

        public override void Parse(string input)
        {
            base.Parse(input);
            Namespace = string.Empty;
            IDictionary<string, string> comps = ParseComponents(input);

            foreach (string property in comps.Keys)
            {
                string value = comps[property];
                switch (property)
                {
                    case "namespace":
                        Namespace = value;
                        break;
                }
            }
        }

        //
        // Unparse the namespace information for a reflection
        // type loading. This will generate a string with the
        // full type name.
        //

        public override string UnparseForType(string typename)
        {
            return base.UnparseForType(Namespace + "." + typename);
        }

        //
        // Unparse the namespace information.
        // String representation for the namespace info.
        //

        public override string Unparse()
        {
            return base.Unparse() + (Namespace.IsNotNullAndEmpty() ? ", Namespace=" + Namespace : string.Empty);
        }

        //
        // STATICS
        //

        public static NamespaceInfo ParseFromString(string input)
        {
            NamespaceInfo ns = new NamespaceInfo();
            ns.Parse(input);
            return ns;
        }
    }
}
