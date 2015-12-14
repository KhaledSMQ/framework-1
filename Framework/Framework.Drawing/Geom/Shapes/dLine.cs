// Toolkit Library
// Description: C# based library of reusable components and software. 
// Author(s): João Paulo Carreiro (joao.carreiro@cybermap.pt)

using System;
using System.Xml.Linq;
using Framework.Core.Extensions;
using Framework.Core.Patterns;

namespace Framework.Drawing.Geom.Shapes
{
    public class dLine : IXmlReady
    {
        public dPoint From { get; set; }

        public dPoint To { get; set; }

        public dLine(dPoint from, dPoint to)
        {
            From = from;
            To = to;
        }

        public dLine(dLine input)
        {
            Change(input);
        }

        public void ChangeFrom(dPoint from)
        {
            From = from;
        }

        public void ChangeTo(dPoint to)
        {
            To = to;
        }

        public void Change(dPoint from, dPoint to)
        {
            From = from;
            To = to;
        }

        public void Change(dLine input)
        {
            Change(input.From, input.To);
        }

        public void ShiftX(double amount)
        {
            From.ShiftX(amount);
            To.ShiftX(amount);
        }

        public void ShiftY(double amount)
        {
            From.ShiftY(amount);
            To.ShiftY(amount);
        }

        public void Shift(double deltaX, double deltaY)
        {
            From.Shift(deltaX, deltaY);
            To.Shift(deltaX, deltaY);
        }

        //
        //  XML
        //  Parsing and Unparsing from and to Xml elements.
        //

        #region Parse/Unparse from/to Xml

        public const string XML_ELM_ROOT = "line";
        private const string XML_ELM_X0 = "x0";
        private const string XML_ELM_Y0 = "y0";
        private const string XML_ELM_X1 = "x1";
        private const string XML_ELM_Y1 = "y1";

        /// <summary>
        /// Parse from a Xml element the definition for a line.
        /// This method will parse the Xml element and build the 
        /// line object instance.
        /// </summary>
        /// <param name="root">the Xml element to parse</param>
        public void ParseFromXml(XElement root)
        {
            root.VerifyName(Config.DEFAULT_XML_NAMESPACE, XML_ELM_ROOT);
            From.X = root.ParseRequiredChildValue_Double(Config.DEFAULT_XML_NAMESPACE, XML_ELM_X0);
            From.Y = root.ParseRequiredChildValue_Double(Config.DEFAULT_XML_NAMESPACE, XML_ELM_Y0);
            To.X = root.ParseRequiredChildValue_Double(Config.DEFAULT_XML_NAMESPACE, XML_ELM_X1);
            To.Y = root.ParseRequiredChildValue_Double(Config.DEFAULT_XML_NAMESPACE, XML_ELM_Y1);
        }

        /// <summary>
        /// Unparse the rectangle to a Xml element.
        /// This method will unparse this rectangle object
        /// instance and generate the Xml definition.
        /// </summary>
        /// <returns>the Xml element the corresponds to this object instance</returns>
        public XElement UnparseToXml()
        {
            XElement root = new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_ROOT);
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_X0, From.X));
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_Y0, From.Y));
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_X1, To.X));
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_Y1, To.Y));
            return root;
        }

        #endregion

        // 
        // Parsing/Unparsing from/to string datatypes.
        // 

        #region Parse/Unparse from/to String

        public const string DEFAULT_X0_AXIS_NAME = "x0";
        public const string DEFAULT_Y0_AXIS_NAME = "y0";
        public const string DEFAULT_X1_AXIS_NAME = "x1";
        public const string DEFAULT_Y1_AXIS_NAME = "y1";
        public const string DEFAULT_AXIS_SEPARATOR = ";";
        public const string DEFAULT_AXIS_VALUE_SEPARATOR = ":";

        /// <summary>
        /// Parse from a string the line information.
        /// Use default settings for parsing method.
        /// </summary>
        /// <param name="input">the input string</param>
        public void ParseFromString(string input)
        {
            ParseFromString(input, DEFAULT_AXIS_SEPARATOR, DEFAULT_AXIS_VALUE_SEPARATOR, DEFAULT_X0_AXIS_NAME, DEFAULT_X1_AXIS_NAME, DEFAULT_X1_AXIS_NAME, DEFAULT_Y1_AXIS_NAME);
        }

        /// <summary>
        /// Parse from a string the line definition.
        /// Set the parsing settings.
        /// </summary>
        /// <param name="input">the input string</param>
        /// <param name="sep">the separator between the x and  y-axis</param>
        /// <param name="sep_axis">the separator between the name of the axis and its value</param>
        /// <param name="x0_axis">the name for the x-axis, e.g. x</param>
        /// <param name="y0_axis">the name for the y-axis, e.g. y</param>
        /// <param name="x1_axis">the name for the x-axis, e.g. x</param>
        /// <param name="y1_axis">the name for the y-axis, e.g. y</param>
        public void ParseFromString(string input, string sep, string sep_axis, string x0_axis, string x1_axis, string y0_axis, string y1_axis)
        {
            Change(dLine.ParseString(input, sep, sep_axis, x0_axis, y0_axis, x1_axis, y1_axis));
        }

        public override string ToString()
        {
            return dLine.UnparseString(this, DEFAULT_AXIS_SEPARATOR, DEFAULT_AXIS_VALUE_SEPARATOR, DEFAULT_X0_AXIS_NAME, DEFAULT_Y0_AXIS_NAME, DEFAULT_X1_AXIS_NAME, DEFAULT_Y1_AXIS_NAME);
        }

        public static dLine ParseString(string input, string sep, string sep_axis, string x0_axis, string y0_axis, string x1_axis, string y1_axis)
        {
            dPoint from = new dPoint();
            dPoint to = new dPoint();

            string[] parcels = input.SplitNoEmpty(sep);
            if (parcels.Length == 4)
            {
                foreach (string parcel in parcels)
                {
                    string[] prop = parcel.SplitNoEmpty(sep_axis);
                    if (prop.Length == 2)
                    {
                        string name = prop[0];
                        string value = prop[1];

                        // parse the property value.
                        double val = double.Parse(value);

                        string lower = name.ToLower();

                        if (lower == x0_axis)
                        {
                            from.X = val;
                        }
                        else if (lower == y0_axis)
                        {
                            from.Y = val;
                        }
                        else if (lower == x1_axis)
                        {
                            to.X = val;
                        }
                        else if (lower == y1_axis)
                        {
                            to.Y = val;
                        }
                        else
                        {
                            throw new Exception("invalid line definition, invalid property '" + name + "'");
                        }
                    }
                    else
                    {
                        throw new Exception("invalid line definition, invalid property '" + parcel + "'");
                    }
                }
            }
            else
            {
                throw new Exception("invalid line definition! '" + input + "'");
            }

            return new dLine(from, to);
        }

        public static string UnparseString(dLine point, string sep, string sep_axis, string x0_axis, string x1_axis, string y0_axis, string y1_axis)
        {
            return dPoint.UnparseString(point.From, sep, sep_axis, x0_axis, y0_axis) + sep + dPoint.UnparseString(point.To, sep, sep_axis, x1_axis, y1_axis);
        }

        #endregion

        /// <summary>
        /// Clone this line object. Return a new line object 
        /// based of the properties of this line object.
        /// </summary>
        /// <returns>the cloned line object instance</returns>
        public dLine Clone()
        {
            return new dLine(this);
        }
    }
}
