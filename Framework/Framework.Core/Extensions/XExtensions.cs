// ============================================================================
// Project: Framework
// Name/Class: XExtensions
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Xml extension methods.
// ============================================================================

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Framework.Core.Types.Specialized;

namespace Framework.Core.Extensions
{
    public static class XExtensions
    {
        //
        // LINE NUMBERS
        //

        #region Line numbers

        // 
        // Get the line number in an XML element (if any).
        // @param elm the element where to extract the line number.
        // @return an optional line number
        //

        public static int? LineNumber(this XElement elm)
        {
            return ((IXmlLineInfo)elm).HasLineInfo() ? ((IXmlLineInfo)elm).LineNumber : default(int);
        }

        #endregion

        //
        // NAME VERIFICATION
        //

        #region Verification (Xml Attributes and Elements)

        //
        // Verify a tag namespace and name. If namespace or name does
        // not verify, throw an exception.
        // @param elm The element where to perform the verification.
        // @param ns The namespace value.
        // @param name The name for the tag.
        //

        public static void VerifyName(this XElement elm, string ns, string name)
        {
            elm.VerifyName(ns, name, true);
        }

        //
        // Verify a tag namespace and name. If namespace or name does
        // not verify, throw an exception.
        // @param elm The element where to perform the verification.
        // @param ns The namespace value.
        // @param name The name for the tag.
        // @param caseInsensitive Whether the verification is case insensitive.
        //

        public static void VerifyName(this XElement elm, string ns, string name, bool caseInsensitive)
        {
            // 
            // Check namespace value.
            //

            if (!string.IsNullOrEmpty(ns))
            {
                if (!elm.Name.NamespaceName.Equals(ns))
                {
                    throw new Exception("element does not belong to namespace '" + ns + "'" + "(found: {" + elm.Name.NamespaceName + "}" + elm.Name.LocalName + ")");
                }
            }

            // 
            // Check tag name.
            //

            if ((caseInsensitive && !elm.Name.LocalName.Equals(name, StringComparison.OrdinalIgnoreCase)) ||
                 !elm.Name.LocalName.Equals(name))
            {
                throw new Exception("element is not named '" + "{" + ns + "}" + name + "'" + "(found: {" + elm.Name.NamespaceName + "}" + elm.Name.LocalName + ")");
            }
        }

        //
        // Verify that an element has exactly one child element.
        // @param elm The element where to perform the verification.
        //

        public static void VerifyExactlyOneChildElement(this XElement elm)
        {
            elm.VerifyExactlyNChildElements(1);
        }

        //
        // Verify that an element has exactly N child element.
        // @param elm The element where to perform the verification.
        // @param N The number of elements to verify.
        //

        public static void VerifyExactlyNChildElements(this XElement elm, int N)
        {
            int numChildren = elm.Elements().Count();
            if (numChildren != N)
            {
                throw new Exception("element '" + elm.Name + "' should have exactly " + N + " child element(s)");
            }
        }

        //
        // Check if element has a specific namespace and name.
        // @param elm The element to check.
        // @param ns The namespace value.
        // @param name The tag name.
        // @param caseInsensitive Whether the verification is case insensitive.
        // @return True if element has a name with the specificed parameters, false otherwise.
        //

        public static bool HasName(this XElement elm, string ns, string name, bool caseInsensitive = true)
        {
            //
            // Check Namespace.
            //

            if (!string.IsNullOrEmpty(ns))
            {
                if (!elm.Name.NamespaceName.Equals(ns))
                {
                    return false;
                }
            }

            //
            // Check name.
            //

            if ((caseInsensitive && !elm.Name.LocalName.Equals(name, StringComparison.OrdinalIgnoreCase)) || !elm.Name.LocalName.Equals(name))
            {
                return false;
            }

            return true;
        }

        //
        // Check if an element has a specific attribute name.
        // @param elm The element to verify.
        // @param ns The namespace value.
        // @param name The attribute name to verify.
        // @return True if element has an attribute with with the specificed parameters, false otherwise.
        //

        public static bool HasAttribute(this XElement elm, string ns, string name)
        {
            bool output = false;

            //
            // If namespace value is null or empty...
            //

            if (!string.IsNullOrEmpty(ns))
            {
                output = null != elm.Attribute("{" + ns + "}" + name);
            }
            else
            {
                output = null != elm.Attribute(name);
            }

            return output;
        }

        #endregion

        //
        // FILTERING
        //

        #region Filter (Xml Attributes)

        /// <summary>
        /// Get a list of attributes, these attributes are specified in a string with names separated
        /// by a specified character, this character has a default value of ';'.
        /// </summary>
        /// <param name="elm">the element to get the attributes from</param>
        /// <param name="names">the list of attribute names to fetch, several attributes are separated by the separator character</param>
        /// <param name="sep">the separator character, default value is ';'</param>
        /// <returns>the list od specified attributes</returns>
        public static IEnumerable<XAttribute> GetAttributes(this XElement elm, string names, char sep = ';')
        {
            return elm.GetAttributes(names.SplitNoEmpty(sep));
        }

        /// <summary>
        /// Get a list of attributes, these attributes are specified in an array of strings
        /// </summary>
        /// <param name="elm">the element to get the attributes from</param>
        /// <param name="names">the array of names</param>
        /// <returns>the list of specified attributes</returns>
        public static IEnumerable<XAttribute> GetAttributes(this XElement elm, params string[] names)
        {
            List<XAttribute> filtered = new List<XAttribute>();
            foreach (string name in names)
            {
                XAttribute att = elm.Attribute(name);
                if (null != att)
                {
                    filtered.Add(att);
                }
            }
            return filtered;
        }

        /// <summary>
        /// Filter out a list of attributes, these attributes are specified in an array of strings
        /// </summary>
        /// <param name="elm">the element to filter the attributes from</param>
        /// <param name="names">the array of names</param>
        /// <returns>the list of removed specified attributes, also attributes are removed from elm</returns>
        public static IEnumerable<XAttribute> FilterAttributes(ref XElement elm, params string[] names)
        {
            IEnumerable<XAttribute> filtered = elm.GetAttributes(names);
            elm.RemoveAttributes();
            elm.Add(filtered);
            return filtered;
        }

        #endregion

        #region Filter (Xml Child Elements)

        public static XElement GetFirstChild(this XElement elm)
        {
            XElement firstChild = null;
            foreach (XElement child in elm.Elements())
            {
                firstChild = child;
                break;
            }
            return firstChild;
        }

        public static XElement GetOptionalChild(this XElement parent, string nsname, string name)
        {
            return parent.GetChild(nsname, name, false);
        }

        public static XElement GetRequiredChild(this XElement parent, string nsname, string name)
        {
            return parent.GetChild(nsname, name, true);
        }

        public static XElement GetChild(this XElement parent, string nsname, string name, bool required)
        {
            XElement child = null;

            // by default, the y for the child element is just the y supplied
            XName childName = name;

            // compute the complete y to filter
            if (!string.IsNullOrEmpty(nsname))
            {
                childName = "{" + nsname + "}" + name;
            }
            else
            {
                // user did not specify a namespace y, check if the parent namespace
                //  y is not folderDelegate or null, if so, use that, otherwise use an folderDelegate 
                // namespace y
                if (!string.IsNullOrEmpty(parent.Name.NamespaceName))
                {
                    childName = "{" + parent.Name.NamespaceName + "}" + name;
                }
            }

            // get the child element
            child = parent.Element(childName);

            // check the required child
            if ((required) && (null == child))
            {
                throw new Exception("element '" + childName + "' is a required child of '" + parent.Name + "'");
            }

            // return the child
            return child;
        }

        #endregion

        //
        // PARSING: ATTRIBUTES
        //

        #region Parsing (Xml Attributes)

        //
        // STRING
        //

        public static string ParseOptionalAttribute_String(this XElement elm, string nsname, string name, string defaultValue, Func<string, string> parserDelegate)
        {
            return elm.ParseOptionalAttribute<string>(nsname, name, defaultValue, parserDelegate);
        }

        public static string ParseRequiredAttribute_String(this XElement elm, string nsname, string name, Func<string, string> parserDelegate)
        {
            return elm.ParseRequiredAttribute<string>(nsname, name, parserDelegate);
        }

        public static string ParseOptionalAttribute_String(this XElement elm, string nsname, string name, string defaultValue)
        {
            return elm.ParseOptionalAttribute<string>(nsname, name, defaultValue, Convert.ToString);
        }

        public static string ParseRequiredAttribute_String(this XElement elm, string nsname, string name)
        {
            return elm.ParseRequiredAttribute<string>(nsname, name, Convert.ToString);
        }

        //
        // DOUBLE
        //

        public static double ParseOptionalAttribute_Double(this XElement elm, string nsname, string name, double defaultValue)
        {
            return elm.ParseOptionalAttribute<double>(nsname, name, defaultValue, Convert.ToDouble);
        }

        public static double ParseOptionalAttribute_Double(this XElement elm, string nsname, string name, double defaultValue, CultureInfo cult)
        {
            return elm.ParseOptionalAttribute<double>(nsname, name, defaultValue, cult, Double.Parse);
        }

        public static double ParseRequiredAttribute_Double(this XElement elm, string nsname, string name)
        {
            return elm.ParseRequiredAttribute<double>(nsname, name, Convert.ToDouble);
        }

        public static double ParseRequiredAttribute_Double(this XElement elm, string nsname, string name, CultureInfo cult)
        {
            return elm.ParseRequiredAttribute<double>(nsname, name, cult, Double.Parse);
        }

        //
        // BOOL
        //

        public static bool ParseOptionalAttribute_YesNo(this XElement elm, string nsname, string name, bool defaultValue)
        {
            string value = elm.ParseOptionalAttribute_String(nsname, name, "no");
            return (value.Trim().ToLower() == "yes");
        }

        public static bool ParseRequiredAttribute_YesNo(this XElement elm, string nsname, string name)
        {
            string value = elm.ParseRequiredAttribute_String(nsname, name);
            return (value.Trim().ToLower() == "yes");
        }

        public static bool ParseOptionalAttribute_Bool(this XElement elm, string nsname, string name, bool defaultValue)
        {
            return elm.ParseOptionalAttribute<bool>(nsname, name, defaultValue, Convert.ToBoolean);
        }

        public static bool ParseRequiredAttribute_Bool(this XElement elm, string nsname, string name)
        {
            return elm.ParseRequiredAttribute<bool>(nsname, name, Convert.ToBoolean);
        }

        //
        // INT
        //

        public static int ParseOptionalAttribute_Int(this XElement elm, string nsname, string name, int defaultValue)
        {
            return elm.ParseOptionalAttribute<int>(nsname, name, defaultValue, Convert.ToInt32);
        }

        public static int ParseRequiredAttribute_Int(this XElement elm, string nsname, string name)
        {
            return elm.ParseRequiredAttribute<int>(nsname, name, Convert.ToInt32);
        }

        //
        // DATETIME
        //

        public static DateTime ParseOptionalAttribute_DateTime(this XElement elm, string nsname, string name, DateTime defaultValue)
        {
            return elm.ParseOptionalAttribute<DateTime>(nsname, name, defaultValue, Convert.ToDateTime);
        }

        public static DateTime ParseOptionalAttribute_DateTime(this XElement elm, string nsname, string name, DateTime defaultValue, CultureInfo cult)
        {
            return elm.ParseOptionalAttribute<DateTime>(nsname, name, defaultValue, cult, DateTime.Parse);
        }

        public static DateTime ParseRequiredAttribute_DateTime(this XElement elm, string nsname, string name)
        {
            return elm.ParseRequiredAttribute<DateTime>(nsname, name, Convert.ToDateTime);
        }

        public static DateTime ParseRequiredAttribute_DateTime(this XElement elm, string nsname, string name, CultureInfo cult)
        {
            return elm.ParseRequiredAttribute<DateTime>(nsname, name, cult, DateTime.Parse);
        }

        //
        // PERCENTAGE
        //

        public static Percentage ParseOptionalAttribute_Percentage(this XElement elm, string nsname, string name, Percentage defaultValue)
        {
            return elm.ParseOptionalAttribute<Percentage>(nsname, name, defaultValue, Percentage.FromString);
        }

        public static Percentage ParseOptionalAttribute_Percentage(this XElement elm, string nsname, string name, Percentage defaultValue, CultureInfo cult)
        {
            return elm.ParseOptionalAttribute<Percentage>(nsname, name, defaultValue, cult, Percentage.FromString);
        }

        public static Percentage ParseRequiredAttribute_Percentage(this XElement elm, string nsname, string name)
        {
            return elm.ParseRequiredAttribute<Percentage>(nsname, name, Percentage.FromString);
        }

        public static Percentage ParseRequiredAttribute_Percentage(this XElement elm, string nsname, string name, CultureInfo cult)
        {
            return elm.ParseRequiredAttribute<Percentage>(nsname, name, cult, Percentage.FromString);
        }

        //
        // DECIMAL
        //

        public static decimal ParseOptionalAttribute_Decimal(this XElement elm, string nsname, string name, decimal defaultValue)
        {
            return elm.ParseOptionalAttribute<decimal>(nsname, name, defaultValue, Convert.ToDecimal);
        }

        public static decimal ParseOptionalAttribute_Decimal(this XElement elm, string nsname, string name, decimal defaultValue, CultureInfo cult)
        {
            return elm.ParseOptionalAttribute<decimal>(nsname, name, defaultValue, cult, Decimal.Parse);
        }

        public static decimal ParseRequiredAttribute_Decimal(this XElement elm, string nsname, string name)
        {
            return elm.ParseRequiredAttribute<decimal>(nsname, name, Convert.ToDecimal);
        }

        public static decimal ParseRequiredAttribute_Decimal(this XElement elm, string nsname, string name, CultureInfo cult)
        {
            return elm.ParseRequiredAttribute<decimal>(nsname, name, cult, Decimal.Parse);
        }

        //
        // PARSE METHODS
        //

        public static T ParseOptionalAttribute<T>(this XElement elm, string nsname, string name, T defaultValue, Func<string, T> parseDelegate)
        {
            return elm.ParseAttribute<T>(nsname, name, false, defaultValue, parseDelegate);
        }

        public static T ParseOptionalAttribute<T>(this XElement elm, string nsname, string name, T defaultValue, CultureInfo cult, Func<string, CultureInfo, T> parseDelegate)
        {
            return elm.ParseAttribute<T>(nsname, name, false, defaultValue, cult, parseDelegate);
        }

        public static T ParseRequiredAttribute<T>(this XElement elm, string nsname, string name, Func<string, T> parseDelegate)
        {
            return elm.ParseAttribute<T>(nsname, name, true, default(T), parseDelegate);
        }

        public static T ParseRequiredAttribute<T>(this XElement elm, string nsname, string name, CultureInfo cult, Func<string, CultureInfo, T> parseDelegate)
        {
            return elm.ParseAttribute<T>(nsname, name, true, default(T), cult, parseDelegate);
        }

        //
        // SETS
        //

        public static T ParseOptionalAttributePropertySet<T>(this XElement elm, string nsname, string name, T defaultValue, params object[] set)
        {
            return elm.ParseAttributePropertySet<T>(nsname, name, false, defaultValue, true, set);
        }

        public static T ParseRequiredAttributePropertySet<T>(this XElement elm, string nsname, string name, params object[] set)
        {
            return elm.ParseAttributePropertySet<T>(nsname, name, true, default(T), true, set);
        }

        // TODO: SHOULDN'T THIS GO UP TO THE PARSE METHODS?
        public static T ParseAttribute<T>(this XElement elm, string nsname, string name, bool required, T defaultValue, Func<string, T> parseDelegate)
        {
            T output = defaultValue;
            XAttribute xAtt = null;

            // if no namespace name is specified, dont use it to fetch attribute
            if (string.IsNullOrEmpty(nsname))
            {
                xAtt = elm.Attribute(name);
            }
            else
            {
                // TODO: Fix this, no namespace uri is being used
                xAtt = elm.Attribute(name);
            }

            // check if attribute exists
            if (null != xAtt)
            {
                if (string.IsNullOrEmpty(xAtt.Value) && required)
                {
                    throw new Exception("attribute '" + nsname + ":" + name + "' is required, but has an empty value!" + " (element:" + elm.Name + ")");
                }

                output = parseDelegate(xAtt.Value);
            }
            else
            {
                // attribute does not exist, is it required, if so, we have an error
                if (required)
                {
                    throw new Exception("attribute '" + nsname + ":" + name + "' is required, but was not found!" + " (element:" + elm.Name + ")");
                }
            }

            return output;
        }

        public static T ParseAttribute<T>(this XElement elm, string nsname, string name, bool required, T defaultValue, CultureInfo cult, Func<string, CultureInfo, T> parseDelegate)
        {
            T output = defaultValue;
            XAttribute xAtt = null;

            // if no namespace name is specified, dont use it to fetch attribute
            if (string.IsNullOrEmpty(nsname))
            {
                xAtt = elm.Attribute(name);
            }
            else
            {
                // TODO: Fix this, no namespace uri is being used
                xAtt = elm.Attribute(name);
            }

            // check if attribute exists
            if (null != xAtt)
            {
                if (string.IsNullOrEmpty(xAtt.Value) && required)
                {
                    throw new Exception("attribute '" + nsname + ":" + name + "' is required, but has an empty value!" + " (element:" + elm.Name + ")");
                }

                output = parseDelegate(xAtt.Value, cult);
            }
            else
            {
                // attribute does not exist, is it required, if so, we have an error
                if (required)
                {
                    throw new Exception("attribute '" + nsname + ":" + name + "' is required, but was not found!" + " (element:" + elm.Name + ")");
                }
            }

            return output;
        }

        public static R ParseAttributePropertySet<R>(this XElement elm, string nsname, string name, bool required, R defaultValue, bool insensitive, params object[] set)
        {
            R output = defaultValue;
            XAttribute xAtt = null;

            // if no namespace name is specified, dont use it to fetch attribute
            if (string.IsNullOrEmpty(nsname))
            {
                xAtt = elm.Attribute(name);
            }
            else
            {
                // TODO: Fix this, no namespace uri is being used
                xAtt = elm.Attribute(name);
            }

            // check if attribute exists
            if (null != xAtt)
            {
                if (string.IsNullOrEmpty(xAtt.Value) && required)
                {
                    throw new Exception("attribute '" + nsname + ":" + name + "' is required, but has an empty value!" + " (element:" + elm.Name + ")");
                }

                output = xAtt.Value.ParseValue_Set<R>(required, defaultValue, insensitive, set);
            }
            else
            {
                // attribute does not exist, is it required, if so, we have an error
                if (required)
                {
                    throw new Exception("attribute '" + nsname + ":" + name + "' is required, but was not found!" + " (element:" + elm.Name + ")");
                }
            }

            return output;
        }

        #endregion

        //
        // PARSING: CHILD ELEMENT VALUES
        //

        #region Parsing (Xml Child Element Values)

        //
        // STRING
        //

        public static string ParseOptionalChildValue_String(this XElement elm, string nsname, string name, string defaultValue, Func<string, string> parseDelegate)
        {
            return elm.ParseOptionalChildValue<string>(nsname, name, defaultValue, parseDelegate);
        }

        public static string ParseRequiredChildValue_String(this XElement elm, string nsname, string name, Func<string, string> parseDelegate)
        {
            return elm.ParseRequiredChildValue<string>(nsname, name, parseDelegate);
        }

        public static string ParseOptionalChildValue_String(this XElement elm, string nsname, string name, string defaultValue)
        {
            return elm.ParseOptionalChildValue<string>(nsname, name, defaultValue, Convert.ToString);
        }

        public static string ParseRequiredChildValue_String(this XElement elm, string nsname, string name)
        {
            return elm.ParseRequiredChildValue<string>(nsname, name, Convert.ToString);
        }

        //
        // DOUBLE
        //

        public static double ParseOptionalChildValue_Double(this XElement elm, string nsname, string name, double defaultValue)
        {
            return elm.ParseOptionalChildValue<double>(nsname, name, defaultValue, Convert.ToDouble);
        }

        public static double ParseOptionalChildValue_Double(this XElement elm, string nsname, string name, double defaultValue, CultureInfo cult)
        {
            return elm.ParseOptionalChildValue<double>(nsname, name, defaultValue, cult, Double.Parse);
        }

        public static double ParseRequiredChildValue_Double(this XElement elm, string nsname, string name)
        {
            return elm.ParseRequiredChildValue<double>(nsname, name, Convert.ToDouble);
        }

        public static double ParseRequiredChildValue_Double(this XElement elm, string nsname, string name, CultureInfo cult)
        {
            return elm.ParseRequiredChildValue<double>(nsname, name, cult, Double.Parse);
        }

        //
        // INT
        //

        public static int ParseOptionalChildValue_Int(this XElement elm, string nsname, string name, int defaultValue)
        {
            return elm.ParseOptionalChildValue<int>(nsname, name, defaultValue, Convert.ToInt32);
        }

        public static int ParseRequiredChildValue_Int(this XElement elm, string nsname, string name)
        {
            return elm.ParseRequiredChildValue<int>(nsname, name, Convert.ToInt32);
        }

        //
        // BOOL
        //

        public static bool ParseOptionalChildValue_Bool(this XElement elm, string nsname, string name, bool defaultValue)
        {
            return elm.ParseOptionalChildValue<bool>(nsname, name, defaultValue, Convert.ToBoolean);
        }

        public static bool ParseRequiredChildValue_Bool(this XElement elm, string nsname, string name)
        {
            return elm.ParseRequiredChildValue<bool>(nsname, name, Convert.ToBoolean);
        }

        //
        // DATETIME
        //

        public static DateTime ParseOptionalChildValue_DateTime(this XElement elm, string nsname, string name, DateTime defaultValue)
        {
            return elm.ParseOptionalChildValue<DateTime>(nsname, name, defaultValue, Convert.ToDateTime);
        }

        public static DateTime ParseOptionalChildValue_DateTime(this XElement elm, string nsname, string name, DateTime defaultValue, CultureInfo cult)
        {
            return elm.ParseOptionalChildValue<DateTime>(nsname, name, defaultValue, cult, DateTime.Parse);
        }

        public static DateTime ParseRequiredChildValue_DateTime(this XElement elm, string nsname, string name)
        {
            return elm.ParseRequiredChildValue<DateTime>(nsname, name, Convert.ToDateTime);
        }

        public static DateTime ParseRequiredChildValue_DateTime(this XElement elm, string nsname, string name, CultureInfo cult)
        {
            return elm.ParseRequiredChildValue<DateTime>(nsname, name, cult, DateTime.Parse);
        }

        //
        // PERCENTAGE
        //

        public static Percentage ParseOptionalChildValue_Percentage(this XElement elm, string nsname, string name, Percentage defaultValue)
        {
            return elm.ParseOptionalChildValue<Percentage>(nsname, name, defaultValue, Percentage.FromString);
        }

        public static Percentage ParseOptionalChildValue_Percentage(this XElement elm, string nsname, string name, Percentage defaultValue, CultureInfo cult)
        {
            return elm.ParseOptionalChildValue<Percentage>(nsname, name, defaultValue, cult, Percentage.FromString);
        }

        public static Percentage ParseRequiredChildValue_Percentage(this XElement elm, string nsname, string name)
        {
            return elm.ParseRequiredChildValue<Percentage>(nsname, name, Percentage.FromString);
        }

        public static Percentage ParseRequiredChildValue_Percentage(this XElement elm, string nsname, string name, CultureInfo cult)
        {
            return elm.ParseRequiredChildValue<Percentage>(nsname, name, cult, Percentage.FromString);
        }

        //
        // DECIMAL
        //

        public static decimal ParseOptionalChildValue_Decimal(this XElement elm, string nsname, string name, decimal defaultValue)
        {
            return elm.ParseOptionalChildValue<decimal>(nsname, name, defaultValue, Convert.ToDecimal);
        }

        public static decimal ParseOptionalChildValue_Decimal(this XElement elm, string nsname, string name, decimal defaultValue, CultureInfo cult)
        {
            return elm.ParseOptionalChildValue<decimal>(nsname, name, defaultValue, cult, Decimal.Parse);
        }

        public static decimal ParseRequiredChildValue_Decimal(this XElement elm, string nsname, string name)
        {
            return elm.ParseRequiredChildValue<decimal>(nsname, name, Convert.ToDecimal);
        }

        public static decimal ParseRequiredChildValue_Decimal(this XElement elm, string nsname, string name, CultureInfo cult)
        {
            return elm.ParseRequiredChildValue<decimal>(nsname, name, cult, Decimal.Parse);
        }

        //
        // PARSE METHODS
        //

        public static T ParseOptionalChildValue<T>(this XElement elm, string nsname, string name, T defaultValue, Func<string, T> parseDelegate)
        {
            return elm.ParseChildValue<T>(nsname, name, false, defaultValue, parseDelegate);
        }

        public static T ParseOptionalChildValue<T>(this XElement elm, string nsname, string name, T defaultValue, CultureInfo cult, Func<string, CultureInfo, T> parseDelegate)
        {
            return elm.ParseChildValue<T>(nsname, name, false, defaultValue, cult, parseDelegate);
        }

        public static T ParseRequiredChildValue<T>(this XElement elm, string nsname, string name, Func<string, T> parseDelegate)
        {
            return elm.ParseChildValue<T>(nsname, name, true, default(T), parseDelegate);
        }

        public static T ParseRequiredChildValue<T>(this XElement elm, string nsname, string name, CultureInfo cult, Func<string, CultureInfo, T> parseDelegate)
        {
            return elm.ParseChildValue<T>(nsname, name, true, default(T), cult, parseDelegate);
        }

        public static T ParseChildValue<T>(this XElement elm, string nsname, string name, bool required, T defaultValue, Func<string, T> parseDelegate)
        {
            XElement child = elm.GetChild(nsname, name, required);
            return (null == child) ? defaultValue : child.ParseValue<T>(required, defaultValue, parseDelegate);
        }

        public static T ParseChildValue<T>(this XElement elm, string nsname, string name, bool required, T defaultValue, CultureInfo cult, Func<string, CultureInfo, T> parseDelegate)
        {
            XElement child = elm.GetChild(nsname, name, required);
            return (null == child) ? defaultValue : child.ParseValue<T>(required, defaultValue, cult, parseDelegate);
        }

        //
        // SETS
        //

        public static T ParseOptionalChildValuePropertySet<T>(this XElement elm, string nsname, string name, T defaultValue, params object[] set)
        {
            return elm.ParseChildValuePropertySet<T>(nsname, name, false, defaultValue, true, set);
        }

        public static T ParseRequiredChildValuePropertySet<T>(this XElement elm, string nsname, string name, params object[] set)
        {
            return elm.ParseChildValuePropertySet<T>(nsname, name, true, default(T), true, set);
        }

        public static R ParseChildValuePropertySet<R>(this XElement elm, string nsname, string name, bool required, R defaultValue, bool insensitive, params object[] set)
        {
            R output = defaultValue;
            XElement child = elm.GetChild(nsname, name, required);

            // check if attribute exists
            if (null != child)
            {
                if (string.IsNullOrEmpty(child.Value) && required)
                {
                    throw new Exception("element '" + nsname + ":" + name + "' is a required child, but has an empty value!" + " (element:" + elm.Name + ")");
                }

                output = child.Value.ParseValue_Set<R>(required, defaultValue, insensitive, set);
            }
            else
            {
                // attribute does not exist, is it required, if so, we have an error
                if (required)
                {
                    throw new Exception("element '" + nsname + ":" + name + "' is a required child, but was not found!" + " (element:" + elm.Name + ")");
                }
            }

            return output;
        }

        #endregion

        //
        // PARSING: ELEMENT VALUES
        //

        #region Parsing (Xml Element Values)

        //
        // STRING
        //

        public static string ParseOptionalValue_String(this XElement elm, string defaultValue, Func<string, string> parserDelegate)
        {
            return elm.ParseOptionalValue<string>(defaultValue, parserDelegate);
        }

        public static string ParseRequiredValue_String(this XElement elm, Func<string, string> parserDelegate)
        {
            return elm.ParseRequiredValue<string>(parserDelegate);
        }

        public static string ParseOptionalValue_String(this XElement elm, string defaultValue)
        {
            return elm.ParseOptionalValue<string>(defaultValue, Convert.ToString);
        }

        public static string ParseRequiredValue_String(this XElement elm)
        {
            return elm.ParseRequiredValue<string>(Convert.ToString);
        }

        //
        // DOUBLE
        //

        public static double ParseOptionalValue_Double(this XElement elm, double defaultValue)
        {
            return elm.ParseOptionalValue<double>(defaultValue, Convert.ToDouble);
        }

        public static double ParseOptionalValue_Double(this XElement elm, double defaultValue, CultureInfo cult)
        {
            return elm.ParseOptionalValue<double>(defaultValue, cult, Double.Parse);
        }

        public static double ParseRequiredValue_Double(this XElement elm)
        {
            return elm.ParseRequiredValue<double>(Convert.ToDouble);
        }

        public static double ParseRequiredValue_Double(this XElement elm, CultureInfo cult)
        {
            return elm.ParseRequiredValue<double>(cult, Double.Parse);
        }

        //
        // BOOL
        //

        public static bool ParseOptionalValue_Bool(this XElement elm, bool defaultValue)
        {
            return elm.ParseOptionalValue<bool>(defaultValue, Convert.ToBoolean);
        }

        public static bool ParseRequiredValue_Bool(this XElement elm)
        {
            return elm.ParseRequiredValue<bool>(Convert.ToBoolean);
        }

        //
        // INTEGER
        //

        public static int ParseOptionalValue_Int(this XElement elm, int defaultValue)
        {
            return elm.ParseOptionalValue<int>(defaultValue, Convert.ToInt32);
        }

        public static int ParseRequiredValue_Int(this XElement elm)
        {
            return elm.ParseRequiredValue<int>(Convert.ToInt32);
        }

        //
        // DATETIME
        //

        public static DateTime ParseOptionalValue_DateTime(this XElement elm, DateTime defaultValue)
        {
            return elm.ParseOptionalValue<DateTime>(defaultValue, Convert.ToDateTime);
        }

        public static DateTime ParseOptionalValue_DateTime(this XElement elm, DateTime defaultValue, CultureInfo cult)
        {
            return elm.ParseOptionalValue<DateTime>(defaultValue, cult, DateTime.Parse);
        }

        public static DateTime ParseRequiredValue_DateTime(this XElement elm)
        {
            return elm.ParseRequiredValue<DateTime>(Convert.ToDateTime);
        }

        public static DateTime ParseRequiredValue_DateTime(this XElement elm, CultureInfo cult)
        {
            return elm.ParseRequiredValue<DateTime>(cult, DateTime.Parse);
        }

        //
        // DOUBLE
        //

        public static decimal ParseOptionalValue_Decimal(this XElement elm, decimal defaultValue)
        {
            return elm.ParseOptionalValue<decimal>(defaultValue, Convert.ToDecimal);
        }

        public static decimal ParseOptionalValue_Decimal(this XElement elm, decimal defaultValue, CultureInfo cult)
        {
            return elm.ParseOptionalValue<decimal>(defaultValue, cult, Decimal.Parse);
        }

        public static decimal ParseRequiredValue_Decimal(this XElement elm)
        {
            return elm.ParseRequiredValue<decimal>(Convert.ToDecimal);
        }

        public static decimal ParseRequiredValue_Decimal(this XElement elm, CultureInfo cult)
        {
            return elm.ParseRequiredValue<decimal>(cult, decimal.Parse);
        }

        //
        // PARSE METHODS
        //

        public static T ParseOptionalValue<T>(this XElement elm, T defaultValue, Func<string, T> parseDelegate)
        {
            return elm.ParseValue<T>(false, defaultValue, parseDelegate);
        }

        public static T ParseOptionalValue<T>(this XElement elm, T defaultValue, CultureInfo cult, Func<string, CultureInfo, T> parseDelegate)
        {
            return elm.ParseValue<T>(false, defaultValue, cult, parseDelegate);
        }

        public static T ParseRequiredValue<T>(this XElement elm, Func<string, T> parseDelegate)
        {
            return elm.ParseValue<T>(true, default(T), parseDelegate);
        }

        public static T ParseRequiredValue<T>(this XElement elm, CultureInfo cult, Func<string, CultureInfo, T> parseDelegate)
        {
            return elm.ParseValue<T>(true, default(T), cult, parseDelegate);
        }

        public static T ParseValue<T>(this XElement elm, bool required, T defaultValue, Func<string, T> parseDelegate)
        {
            T output = defaultValue;
            string value = elm.Value;
            if (!string.IsNullOrEmpty(value))
            {
                output = parseDelegate(value);
            }
            else
            {
                if (required)
                {
                    throw new Exception("element '" + elm.Name + "' is required to have a non empty value!");
                }
            }
            return output;
        }

        public static T ParseValue<T>(this XElement elm, bool required, T defaultValue, CultureInfo cult, Func<string, CultureInfo, T> parseDelegate)
        {
            T output = defaultValue;
            string value = elm.Value;
            if (!string.IsNullOrEmpty(value))
            {
                output = parseDelegate(value, cult);
            }
            else
            {
                if (required)
                {
                    throw new Exception("element '" + elm.Name + "' is required to have a non empty value!");
                }
            }
            return output;
        }

        //
        // SETS
        //

        public static T ParseOptionalValuePropertySet<T>(this XElement elm, string nsname, string name, T defaultValue, params object[] set)
        {
            return elm.ParseValuePropertySet<T>(nsname, name, false, defaultValue, true, set);
        }

        public static T ParseRequiredValuePropertySet<T>(this XElement elm, string nsname, string name, params object[] set)
        {
            return elm.ParseValuePropertySet<T>(nsname, name, true, default(T), true, set);
        }

        public static R ParseValuePropertySet<R>(this XElement elm, string nsname, string name, bool required, R defaultValue, bool insensitive, params object[] set)
        {
            R output = defaultValue;

            // check if attribute exists
            if (null != elm)
            {
                if (string.IsNullOrEmpty(elm.Value) && required)
                {
                    throw new Exception("element '" + nsname + ":" + name + "' is required, but has an empty value!" + " (element:" + elm.Name + ")");
                }

                output = elm.Value.ParseValue_Set<R>(required, defaultValue, insensitive, set);
            }
            else
            {
                // attribute does not exist, is it required, if so, we have an error
                if (required)
                {
                    throw new Exception("element '" + nsname + ":" + name + "' is required, but was not found!" + " (element:" + elm.Name + ")");
                }
            }

            return output;
        }

        #endregion

        //
        // PARSING: CHILD COLLECTIONS
        //

        #region Parsing (Xml Child Collections)

        public static List<T> ParseListOfChildren<T>(this XElement elm, Func<XElement, T> gene)
        {
            List<T> parsedList = new List<T>();
            foreach (XElement child in elm.Elements()) { parsedList.Add(gene(child)); };
            return parsedList;
        }

        public static List<T> ParseListOfChildren<T>(this XElement elm, string nsname, string name, Func<XElement, T> gene)
        {
            List<T> parsedList = new List<T>();
            string elmCompleteName = string.Empty;

            // get the complete/parcial y for the children elements
            if (string.IsNullOrEmpty(name))
            {
                elmCompleteName = "{" + nsname + "}" + name;
            }
            else
            {
                elmCompleteName = name;
            }

            // get all children that satisfy the supplied y
            foreach (XElement child in elm.Elements(elmCompleteName)) { parsedList.Add(gene(child)); };
            return parsedList;
        }

        public static IDictionary<string, T> ParseDictionaryOfChildren<T>(this XElement elm, string nsname, string name, string keyatt, Func<XElement, T> gene)
        {
            SortedDictionary<string, T> parsedDict = new SortedDictionary<string, T>();
            string elmCompleteName = string.Empty;

            // get the complete/parcial y for the children elements
            if (string.IsNullOrEmpty(name))
            {
                elmCompleteName = "{" + nsname + "}" + name;
            }
            else
            {
                elmCompleteName = name;
            }

            // get all children that satisfy the supplied y
            foreach (XElement child in elm.Elements(elmCompleteName))
            {
                // parse key value attribute and the element
                string key = child.ParseRequiredAttribute_String(nsname, keyatt);
                parsedDict.Add(key, gene(child));
            };

            return parsedDict;
        }

        #endregion

        #region Unparsing (Xml Attributes)

        public static void UnparseOptionalAttribute(this XElement elm, string prefix, string name, object value, Func<object, string> unparseDelegate = null)
        {
            elm.UnparseAttribute<object>(prefix, name, value, false, unparseDelegate);
        }

        public static void UnparseRequiredAttribute(this XElement elm, string prefix, string name, object value, Func<object, string> unparseDelegate = null)
        {
            elm.UnparseAttribute<object>(prefix, name, value, true, unparseDelegate);
        }

        public static void UnparseAttribute<T>(this XElement elm, string prefix, string name, T value, bool required, Func<T, string> unparseDelegate)
        {
            string objValue = string.Empty;

            // generate string representation for value
            if (null == unparseDelegate)
            {
                objValue = value.ToString();
            }
            else
            {
                objValue = unparseDelegate(value);
            }

            // add attribute to element
            if (required)
            {
                if (!string.IsNullOrEmpty(objValue))
                {
                    elm.Add(new XAttribute(name, objValue));
                }
                else
                {
                    throw new Exception("attribute '" + name + "' must have a value");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(objValue))
                {
                    elm.Add(new XAttribute(name, objValue));
                }
            }
        }

        #endregion

        //
        // TOKEN INSTANTIATION
        //

        #region Token Instantiation

        //
        // Take a Xml document and instantiate the tokens set. This will replace all tokens 
        // found with the actual values.
        // @param doc The document where to replace the tokens.
        // @param tokens The token mapping.
        // @return A new Xml document with the tokens instantiated.
        //

        public static XDocument ReplaceTokens(this XDocument doc, IDictionary<string, object> tokens)
        {
            return new XDocument(doc.Declaration, doc.Root.ReplaceTokens(tokens));
        }

        //
        // Take a Xml element and instantiate the tokens set. This will replace all tokens 
        // found with the actual values.
        // @param doc The document where to replace the tokens.
        // @param tokens The token mapping.
        // @return A new Xml document with the tokens instantiated.
        //

        public static XElement ReplaceTokens(this XElement elm, IDictionary<string, object> tokens)
        {
            string origElmStr = elm.ToString();
            string instElmStr = tokens.ApplyTemplate(origElmStr);
            return XElement.Parse(instElmStr);
        }

        #endregion
    }
}
