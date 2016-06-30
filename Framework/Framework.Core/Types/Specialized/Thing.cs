// ============================================================================
// Project: Framework - Data
// Name/Class: Thing
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: IThing implementation class.
// ============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Framework.Core.Extensions;
using Framework.Core.Patterns;

namespace Framework.Core.Types.Specialized
{
    public class Thing : SortedDictionary<string, object>, IThing
    {
        //
        // GET/SET (generic information about ITEM)
        // 

        public IEnumerable<string> Names
        {
            get { return GetOrderedPropertyNames(); }
        }

        public new IEnumerable<object> Values
        {
            get { return GetOrderedPropertyValues(); }
        }

        //
        // CONSTRUCTORS
        //

        public Thing() : base() { }

        //
        // GET/SET PROPERTIES (based on NAME)
        //

        public object GetProperty(string name)
        {
            if (string.IsNullOrEmpty(name) || !ContainsKey(name))
            {
                throw new Exception(string.Format("{0}: invalid property name '{1}' in get property", Lib.DEFAULT_ERROR_MSG_PREFIX, name));
            }

            return this[name];
        }

        public object GetOptionalProperty(string name, object dftValue)
        {
            if (!ContainsKey(name)) return dftValue;
            return GetProperty(name);
        }

        public O GetProperty<O>(string name, Func<object, object, O> converter)
        {
            return converter(GetProperty(name), null);
        }

        public O GetOptionalProperty<O>(string name, Func<object, object, O> converter, object dftValue)
        {
            return converter(GetOptionalProperty(name, dftValue), null);
        }

        public void SetProperty(string name, object value)
        {
            if (string.IsNullOrEmpty(name) || !ContainsKey(name))
            {
                throw new Exception(string.Format("{0}: invalid property name '{1}' in set property", Lib.DEFAULT_ERROR_MSG_PREFIX, name));
            }

            this[name] = value;
        }

        public void UpdateOrAddProperty(string name, object value)
        {
            this[name] = value;
        }

        //
        // HELPER METHODS
        //

        public IEnumerable<string> GetOrderedPropertyNames()
        {

            return Keys.ToList();
        }

        public IEnumerable<object> GetOrderedPropertyValues()
        {

            return Values.ToList();
        }

        //
        // XML-PARSING/UNPARSING
        //

        public const string XML_ELM_THING = "Thing";
        public const string XML_ELM_THING_PROPERTY = "Property";
        public const string XML_ELM_THING_PROPERTY_NAME = "Name";
        public const string XML_ELM_THING_PROPERTY_VALUE = "Value";

        public void ParseFromXml(XElement elm)
        {
            ParseFromXml(elm, Lib.DEFAULT_XML_NAMESPACE, XML_ELM_THING);
        }

        public void ParseFromXml(XElement elm, string ns, string tag)
        {
            //
            // Verify the namespace and tag.
            //

            elm.VerifyName(ns, tag);

            //
            // Clear the current thing.
            //

            Clear();

            //
            // Parse the thing property name and values.
            //

            elm.Elements((XNamespace)ns + XML_ELM_THING_PROPERTY).Apply(xProperty =>
            {
                //
                // Parse the name and value for property.
                //

                string pName = xProperty.ParseRequiredChildValue_String(ns, XML_ELM_THING_PROPERTY_NAME);
                string pValue = xProperty.ParseRequiredChildValue_String(ns, XML_ELM_THING_PROPERTY_VALUE);

                //
                // Add it to item.
                //

                UpdateOrAddProperty(pName, pValue);
            });
        }

        public XElement UnparseToXml()
        {
            return UnparseToXml(Lib.DEFAULT_XML_NAMESPACE, XML_ELM_THING);
        }

        public XElement UnparseToXml(string ns, string tag)
        {
            //
            // Create the thing root Xml element.
            //

            XElement elm = new XElement((XNamespace)ns + tag);

            //
            // Unparse the thing properties.
            //

            Names.Apply(pName =>
            {
                XElement xProperty = new XElement((XNamespace)ns + XML_ELM_THING_PROPERTY);
                xProperty.Add(new XElement((XNamespace)ns + XML_ELM_THING_PROPERTY_NAME, pName));
                xProperty.Add(new XElement((XNamespace)ns + XML_ELM_THING_PROPERTY_VALUE, GetProperty(pName)));

                elm.Add(xProperty);
            });

            return elm;
        }

        //
        // STANDARD METHODS 
        //

        public override string ToString()
        {
            return this.UnparseToString("{", "}", ",");
        }

        //
        // STATIC METHODS 
        //

        public static IThing Create(params object[] args)
        {
            IThing item = new Thing();

            if (!args.Length.IsEven())
            {
                throw new Exception(string.Format("{0}: invalid number of parameters '{1}' to item value variant create method", Lib.DEFAULT_ERROR_MSG_PREFIX, args.Length));
            }

            for (int i = 0; i < args.Length; i = i + 2)
            {
                if (args[i].GetType() == typeof(string))
                {
                    string name = (string)args[i];
                    item[name] = args[i + 1];
                }
                else
                {
                    throw new Exception(string.Format("{0}: invalid type for name of property '{1}' to item value variant create method", Lib.DEFAULT_ERROR_MSG_PREFIX, args[i].GetType()));
                }
            }

            return item;
        }
    }
}
