// ============================================================================
// Project: Framework
// Name/Class: XRef
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Namespace and name reference.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using System;
using System.Xml.Linq;

namespace Framework.Core.Types.Specialized
{
    public class XRef : IXRef, IComparable
    {
        //
        // PROPERTIES
        //

        public string Namespace { get; set; }
        public string Name { get; set; }

        //
        // CONSTRUCTORS
        //

        public XRef() : this(string.Empty, string.Empty) { }

        public XRef(string ns, string name)
        {
            Namespace = ns;
            Name = name;
        }

        public XRef(XElement elm, string ns, string name, string tag_ns, string tag_name)
            : this()
        {
            ParseFromXml(elm, ns, name, tag_ns, tag_name);
        }

        //
        // XML PARSING/UNPARSING
        // PArse and Unparse from/to a Xml element.
        //

        public void ParseFromXml(XElement elm, string ns, string name, string tag_ns, string tag_name)
        {
            elm.VerifyName(ns, name);
            Namespace = elm.ParseRequiredChildValue_String(ns, tag_ns);
            Name = elm.ParseRequiredChildValue_String(ns, tag_name);
        }

        public XElement UnparseToXml(string ns, string name, string tag_ns, string tag_name)
        {
            XElement elm = new XElement((XNamespace)ns + name);
            elm.Add(new XElement(((XNamespace)ns) + tag_ns, Namespace));
            elm.Add(new XElement(((XNamespace)ns) + tag_name, Name));
            return elm;
        }

        //
        // TO-STRING
        // String represention for reference.
        //

        public override string ToString()
        {
            return "[" + Namespace + "]:" + Name;
        }

        //
        // HASH-CODE
        // Return the hash code for this object.
        //

        public override int GetHashCode()
        {
            return string.Concat(Namespace, ":", Name).GetHashCode();
        }

        //
        // COMPARABLE-INTERFACE
        // Compare method for XRef.
        //

        public int CompareTo(object obj)
        {
            int result = -1;

            if (obj is XRef)
            {
                XRef refn = obj as XRef;

                int thisHC = this.GetHashCode();
                int objHC = refn.GetHashCode();

                if (thisHC < objHC)
                {
                    result = -1;
                }
                else
                    if (thisHC == objHC)
                    {
                        result = 0;
                    }
                    else
                    {
                        result = 1;
                    }
            }

            return result;
        }
    }
}
