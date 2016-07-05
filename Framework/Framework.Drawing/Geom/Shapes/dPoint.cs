// Framework Library
// Description: C# based library of reusable components and software. 
// Author(s): João Paulo Carreiro (joaopaulocarreiro@gmail.com)

using System;
using System.Xml.Linq;
using Framework.Core.Extensions;
using Framework.Core.Patterns;

namespace Framework.Drawing.Geom.Shapes
{
    public class dPoint : IXmlReady
    {
        /// <summary>
        /// The x-axis value for the point.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// The y-axis value for the point.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Default constructor. Initialize the point at the origin.
        /// </summary>
        public dPoint() : this(0.0f, 0.0f) { }

        /// <summary>
        /// Create a new point. Define the X and Y coordinates.
        /// </summary>
        /// <param name="x">the X coordinate</param>
        /// <param name="y">the Y coordinate</param>
        public dPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Create a new point. Use the definition of another point.
        /// </summary>
        /// <param name="input">the point definition to use</param>
        public dPoint(dPoint input)
        {
            Change(input);
        }

        /// <summary>
        /// Change the X-axis value.
        /// </summary>
        /// <param name="x">the new X-axis value</param>
        public void ChangeX(double x)
        {
            X = x;
        }

        /// <summary>
        /// Change the Y-axis value.
        /// </summary>
        /// <param name="y">the new Y-axis value</param>
        public void ChangeY(double y)
        {
            Y = y;
        }

        /// <summary>
        /// Change the X and Y-axis values.
        /// </summary>
        /// <param name="x">the new X-axis value</param>
        /// <param name="y">the new Y-axis value</param>
        public void Change(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Change this point definition using another point definition.
        /// </summary>
        /// <param name="input">the point definition to use</param>
        public void Change(dPoint input)
        {
            X = input.X;
            Y = input.Y;
        }

        /// <summary>
        /// Shift the location of this point in the X-axis.
        /// </summary>
        /// <param name="amount">the amount to shift</param>
        public void ShiftX(double amount)
        {
            ChangeX(X + amount);
        }

        /// <summary>
        /// Shift the location of this point in the Y-axis.
        /// </summary>
        /// <param name="amount">the amount to shift</param>
        public void ShiftY(double amount)
        {
            ChangeY(Y + amount);
        }

        /// <summary>
        /// Shift this point location. 
        /// </summary>
        /// <param name="deltaX">the amount to shift in the X-axis</param>
        /// <param name="deltaY">the amount to shift in the Y-axis</param>
        public void Shift(double deltaX, double deltaY)
        {
            Change(X + deltaX, Y + deltaY);
        }

        //
        //  XML
        //  Parsing and Unparsing from and to Xml elements.
        //

        #region Parse/Unparse from/to Xml

        public const string XML_ELM_ROOT = "point";
        private const string XML_ELM_X = "x";
        private const string XML_ELM_Y = "y";

        /// <summary>
        /// Parse from a Xml element the definition for a point.
        /// This method will parse the Xml element and build the 
        /// point object instance.
        /// </summary>
        /// <param name="root">the Xml element to parse</param>
        public void ParseFromXml(XElement root)
        {
            // verifiy tag
            root.VerifyName(Config.DEFAULT_XML_NAMESPACE, XML_ELM_ROOT);

            // parse coordinates.
            X = root.ParseRequiredChildValue_Double(Config.DEFAULT_XML_NAMESPACE, XML_ELM_X);
            Y = root.ParseRequiredChildValue_Double(Config.DEFAULT_XML_NAMESPACE, XML_ELM_Y);
        }

        /// <summary>
        /// Unparse the point to a Xml element.
        /// This method will unparse this point object
        /// instance and generate the Xml definition.
        /// </summary>
        /// <returns>the Xml element the corresponds to this layout object instance</returns>
        public XElement UnparseToXml()
        {
            XElement root = new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_ROOT);
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_X, X));
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_Y, Y));
            return root;
        }

        #endregion

        // 
        // STRING PARSING
        // Parsing/Unparsing from/to string datatypes.
        // 

        #region Parse/Unparse from/to String

        public const string DEFAULT_X_AXIS_NAME = "x";
        public const string DEFAULT_Y_AXIS_NAME = "y";
        public const string DEFAULT_AXIS_SEPARATOR = ";";
        public const string DEFAULT_AXIS_VALUE_SEPARATOR = ":";

        /// <summary>
        /// Parse from a string the point information.
        /// Use default settings for parsing method.
        /// </summary>
        /// <param name="input">the input string</param>
        public void ParseFromString(string input)
        {
            ParseFromString(input, DEFAULT_AXIS_SEPARATOR, DEFAULT_AXIS_VALUE_SEPARATOR, DEFAULT_X_AXIS_NAME, DEFAULT_Y_AXIS_NAME);
        }

        /// <summary>
        /// Parse from a string the point definition.
        /// Set the parsing settings.
        /// </summary>
        /// <param name="input">the input string</param>
        /// <param name="sep">the separator between the x and  y-axis</param>
        /// <param name="sep_axis">the separator between the name of the axis and its value</param>
        /// <param name="x_axis">the name for the x-axis, e.g. x</param>
        /// <param name="y_axis">the name for the y-axis, e.g. y</param>
        public void ParseFromString(string input, string sep, string sep_axis, string x_axis, string y_axis)
        {
            dPoint.ParseString(input, sep, sep_axis, x_axis, y_axis);
        }

        /// <summary>
        /// Unparse the point definition to a string.
        /// Use default unparsing settings.
        /// </summary>
        /// <returns>the string representation</returns>
        public string UnparseToString()
        {
            return UnparseToString(DEFAULT_AXIS_SEPARATOR, DEFAULT_AXIS_VALUE_SEPARATOR, DEFAULT_X_AXIS_NAME, DEFAULT_Y_AXIS_NAME);
        }

        /// <summary>
        /// Unparse the point definition to a string.
        /// Set the unparsing settings.
        /// </summary>
        /// <param name="sep">the separator between the x and  y-axis</param>
        /// <param name="sep_axis">the separator between the name of the axis and its value</param>
        /// <param name="x_axis">the name for the x-axis, e.g. x</param>
        /// <param name="y_axis">the name for the y-axis, e.g. y</param>
        /// <returns>the unparsed point definition</returns>
        public string UnparseToString(string sep, string sep_axis, string x_axis, string y_axis)
        {
            return dPoint.UnparseString(this, sep, sep_axis, x_axis, y_axis);
        }

        /// <summary>
        /// String representation for the point.
        /// Use the unparsing method with standard unparsing settings.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return UnparseToString(DEFAULT_AXIS_SEPARATOR, DEFAULT_AXIS_VALUE_SEPARATOR, DEFAULT_X_AXIS_NAME, DEFAULT_Y_AXIS_NAME);
        }

        /// <summary>
        /// Static method to parse the point definition.
        /// </summary>
        /// <param name="input">the input string to parse</param>
        /// <param name="sep">the separator between the x and  y-axis</param>
        /// <param name="sep_axis">the separator between the name of the axis and its value</param>
        /// <param name="x_axis">the name for the x-axis, e.g. x</param>
        /// <param name="y_axis">the name for the y-axis, e.g. y</param>
        /// <returns>the parsed point object instance</returns>
        public static dPoint ParseString(string input, string sep, string sep_axis, string x_axis, string y_axis)
        {
            dPoint point = new dPoint();
            string[] parcels = input.SplitNoEmpty(sep);
            if (parcels.Length == 2)
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

                        if (lower == x_axis)
                        {
                            point.X = val;
                        }
                        else if (lower == y_axis)
                        {
                            point.Y = val;
                        }
                        else
                        {
                            throw new Exception("invalid point definition, invalid property '" + name + "'");
                        }
                    }
                    else
                    {
                        throw new Exception("invalid point definition, invalid property '" + parcel + "'");
                    }
                }
            }
            else
            {
                throw new Exception("invalid point definition! '" + input + "'");
            }

            return point;
        }

        /// <summary>
        /// Static method to unparse a point definition.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="sep">the separator between the x and  y-axis</param>
        /// <param name="sep_axis">the separator between the name of the axis and its value</param>
        /// <param name="x_axis">the name for the x-axis, e.g. x</param>
        /// <param name="y_axis">the name for the y-axis, e.g. y</param>
        /// <returns>the unparsed point definition as a string</returns>
        public static string UnparseString(dPoint point, string sep, string sep_axis, string x_axis, string y_axis)
        {
            return x_axis + sep_axis + point.X + sep + y_axis + sep_axis + point.Y;
        }

        #endregion

        /// <summary>
        /// Clone this point definition.
        /// </summary>
        /// <returns>a new point, with the same values</returns>
        public dPoint Clone()
        {
            return new dPoint(this);
        }
    }
}