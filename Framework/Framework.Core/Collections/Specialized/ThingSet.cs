﻿// ============================================================================
// Project: Framework - Data
// Name/Class: ThingSet
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: IThingSet implementation class.
// ============================================================================

using System.Collections.Generic;
using System.Xml.Linq;
using Framework.Core.Types.Specialized;
using Framework.Core.Extensions;
using Framework.Core.Patterns;

namespace Framework.Core.Collections.Specialized
{
    public class ThingSet : List<IThing>, IThingSet, IXmlReady
    {
        //
        // CONSTRUCTORS
        //  

        public ThingSet() : base() { }

        //
        // CHANGE LIST BEHAVIOUR - METHODS
        //

        public new IThing this[int index]
        {
            get { return base[index]; }
            set { SetItemAtIndex(index, value); }
        }

        //
        // HELPER METHODS
        //

        public void SetItemAtIndex(int index, IThing item)
        {
            base[index] = item;
        }

        //
        // XML-PARSING/UNPARSING
        //

        public const string XML_ELM_THING_SET = "Set";

        public void ParseFromXml(XElement elm)
        {
            //
            // Verifiy the namespace and name for thing set.
            //

            elm.VerifyName(Config.DEFAULT_XML_NAMESPACE, XML_ELM_THING_SET);

            //
            // Clear current list of thing items.
            //

            Clear();

            //
            // Parse all things from Xml.
            //

            elm.Elements().Apply(xThing =>
            {
                IThing thing = new Thing();
                thing.ParseFromXml(xThing);
                Add(thing);
            });
        }

        public XElement UnparseToXml()
        {
            XElement elm = new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_THING_SET);
            this.Apply(thing => elm.Add(thing.UnparseToXml()));
            return elm;
        }

        //
        // STANDARD
        //

        public override string ToString()
        {
            return this.UnparseToString("[", "]", ",");
        }
    }
}
