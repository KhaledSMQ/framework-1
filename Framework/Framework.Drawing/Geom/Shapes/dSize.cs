// Toolkit Library
// Description: C# based library of reusable components and software. 
// Author(s): João Paulo Carreiro (joaopaulocarreiro@gmail.com)

using System;
using System.Xml.Linq;
using Framework.Core.Extensions;
using Framework.Core.Patterns;

namespace Framework.Drawing.Geom.Shapes
{
    public class dSize : IXmlReady
    {
        /// <summary>
        /// Width of size (X-axis).
        /// </summary>
        public double W { get; set; }

        /// <summary>
        /// Height of size (Y-axis)
        /// </summary>
        public double H { get; set; }

        /// <summary>
        /// Default constructor. Creates a size with 0 
        /// at its width and height.
        /// </summary>
        public dSize() : this(0, 0) { }

        /// <summary>
        /// Construct a new size, setting all relevant properties.
        /// </summary>
        /// <param name="w">the width for the size</param>
        /// <param name="h">the height for the size</param>
        public dSize(double w, double h)
        {
            Change(w, h);
        }

        /// <summary>
        /// Construct a new size based of an existent size.
        /// This constructor will extract size properties of the 
        /// supplied object and build a new one.
        /// </summary>
        /// <param name="size">the size where to extract the properties</param>
        public dSize(dSize size)
        {
            Change(size);
        }

        /// <summary>
        /// Method to change the width of the this size object.
        /// </summary>
        /// <param name="w">the new width</param>
        public void ChangeW(double w)
        {
            W = w;
        }

        /// <summary>
        /// Method to change the height of the this size object.
        /// </summary>
        /// <param name="h">the new height</param>
        public void ChangeH(double h)
        {
            H = h;
        }

        /// <summary>
        /// Method to change the width and height of the this size object.
        /// </summary>
        /// <param name="w">the new width</param>
        /// <param name="h">the new height</param>
        public void Change(double w, double h)
        {
            W = w;
            H = h;
        }

        /// <summary>
        /// Method to change some of the shape' s properties.
        /// Taking a already defined shape. The outcome of this
        /// operation is that this shape will have the same values
        /// for all its properties as the supplied shape.
        /// </summary>
        /// <param name="shape">the shape to extract the properties</param>
        public void Change(dSize size)
        {
            Change(size.W, size.H);
        }

        /// <summary>
        /// Stretch the shape in a defined width and height. By
        /// streching we mean a delta in size, both in width and height.
        /// Negative values are allowed.
        /// </summary>
        /// <param name="deltaW">the amount to strech in width</param>
        /// <param name="deltaH">the amount to stretch in height</param>
        public void Stretch(double deltaW, double deltaH)
        {
            Change(W + deltaW, H + deltaH);
        }

        //
        //  XML
        //  Parsing and Unparsing from and to Xml elements.
        //

        #region Parse/Unparse from/to Xml

        public const string XML_ELM_ROOT = "size";
        private const string XML_ELM_WIDTH = "width";
        private const string XML_ELM_HEIGHT = "height";

        /// <summary>
        /// Parse from a Xml element the definition for a size.
        /// This method will parse the Xml element and build the 
        /// size object instance.
        /// </summary>
        /// <param name="root">the Xml element to parse</param>
        public void ParseFromXml(XElement root)
        {
            root.VerifyName(Config.DEFAULT_XML_NAMESPACE, XML_ELM_ROOT);
            W = root.ParseRequiredChildValue_Double(Config.DEFAULT_XML_NAMESPACE, XML_ELM_WIDTH);
            H = root.ParseRequiredChildValue_Double(Config.DEFAULT_XML_NAMESPACE, XML_ELM_HEIGHT);
        }

        /// <summary>
        /// Unparse the layout to a Xml element.
        /// This method will unparse this layout object
        /// instance and generate the Xml definition.
        /// </summary>
        /// <returns>the Xml element the corresponds to this layout object instance</returns>
        public XElement UnparseToXml()
        {
            XElement root = new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_ROOT);
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_WIDTH, W));
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_HEIGHT, H));
            return root;
        }

        #endregion

        /// <summary>
        /// String representation for the size object instance.
        /// </summary>
        /// <returns>the string representation</returns>
        public override string ToString()
        {
            return "Width:" + W + " " + "Height:" + H;
        }

        /// <summary>
        /// Clone this size, returning a new size.
        /// </summary>
        /// <returns>the new size</returns>
        public dSize Clone()
        {
            return new dSize(this);
        }

        /// <summary>
        /// Parse a shape definitiion from a strinf value.
        /// Break down the shape string and parse individual
        /// shape components. If the string is not a valid shape
        /// object, then throw an exception.
        /// </summary>
        /// <param name="input">the input string to parse</param>
        /// <returns>the parsed shape</returns>
        public static dRect ParseFromString(string input)
        {
            dRect shape = new dRect();
            string[] parcels = input.SplitNoEmpty(";");
            if (parcels.Length == 4)
            {
                foreach (string parcel in parcels)
                {
                    string[] prop = parcel.SplitNoEmpty(":");
                    if (prop.Length == 2)
                    {
                        string name = prop[0];
                        string value = prop[1];

                        // parse the property value.
                        double val = double.Parse(value);

                        switch (name.ToLower())
                        {
                            case "x": shape.X = val; break;
                            case "y": shape.Y = val; break;
                            case "w": shape.W = val; break;
                            case "h": shape.H = val; break;
                            default:
                                throw new Exception("invalid rectangle deinition, invalid property '" + name + "'");

                        }
                    }
                    else
                        throw new Exception("invalid rectangle deinition, invalid property '" + parcel + "'");
                }
            }
            else
                throw new Exception("invalid rectangle deinition! '" + input + "'");

            // return the parsed shape.
            return shape;
        }
    }
}
