// Framework Library
// Description: C# based library of reusable components and software. 
// Author(s): João Paulo Carreiro (joaopaulocarreiro@gmail.com)

using System;
using System.Xml.Linq;
using Framework.Core.Extensions;
using Framework.Core.Patterns;

namespace Framework.Drawing.Geom.Shapes
{
    /// <summary>
    /// Class to model a rectangular shape.
    /// Used to represent a number os thingsin the system, from
    /// windows to placeholders.
    /// </summary>
    public class fRect : IXmlReady
    {
        /// <summary>
        /// X-coordinate for the shape.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Y-coordinate for the shape.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Width of shape (X-axis).
        /// </summary>
        public float W { get; set; }

        /// <summary>
        /// Height of shape (Y-axis)
        /// </summary>
        public float H { get; set; }

        /// <summary>
        /// Default constructor. Creates a shape located at (0,0)
        /// with 0 set as its width and height.
        /// </summary>
        public fRect() : this(0, 0, 0, 0) { }

        /// <summary>
        /// Construct a new shape, setting all relevant properties.
        /// </summary>
        /// <param name="x">the location at the X-axis</param>
        /// <param name="y">the location at the Y-axis</param>
        /// <param name="w">the width for the shape</param>
        /// <param name="h">the height for the shape</param>
        public fRect(float x, float y, float w, float h)
        {
            Change(x, y, w, h);
        }

        /// <summary>
        /// Construct a new rectangle based of an existent rectangle.
        /// This constructor will extract the location and size of the 
        /// supplied rectangle and build a new one.
        /// </summary>
        /// <param name="shape">the rectangle where to extract the location and size</param>
        public fRect(fRect shape)
        {
            Change(shape);
        }

        /// <summary>
        /// Method to change some of the shape's properties.
        /// In this specific case, change the X and Y coordinates.
        /// </summary>
        /// <param name="x">the new X-coordinate</param>
        /// <param name="y">the new Y-coordinate</param>
        public void ChangeXY(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Method to change some of the shape's properties.
        /// In this specific case, the width and height for the shape.
        /// </summary>
        /// <param name="w">the new width</param>
        /// <param name="h">the new height</param>
        public void ChangeWH(float w, float h)
        {
            W = w;
            H = h;
        }

        /// <summary>
        /// Method to change some of the shape' s properties.
        /// In this specific case, the X and Y coordinates, but
        /// also the width and height of the shape.
        /// </summary>
        /// <param name="x">the new X-coordinate</param>
        /// <param name="y">the new Y-coordinate</param>
        /// <param name="w">the new width</param>
        /// <param name="h">the new height</param>
        public void Change(float x, float y, float w, float h)
        {
            X = x;
            Y = y;
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
        public void Change(fRect shape)
        {
            Change(shape.X, shape.Y, shape.W, shape.H);
        }

        /// <summary>
        /// Shift this shape position in the X and Y axis.
        /// Negative values allow the shape to move to left
        /// in the X-axis and up in th Y-axis.
        /// </summary>
        /// <param name="deltaX">the amount to move in the X-axis</param>
        /// <param name="deltaY">the amount to move in the Y-axis</param>
        public void Shift(float deltaX, float deltaY)
        {
            ChangeXY(X + deltaX, Y + deltaY);
        }

        /// <summary>
        /// Stretch the shape in a defined width and height. By
        /// streching we mean a delta in size, both in width and height.
        /// Negative values are allowed.
        /// </summary>
        /// <param name="deltaW">the amount to strech in width</param>
        /// <param name="deltaH">the amount to stretch in height</param>
        public void Stretch(float deltaW, float deltaH)
        {
            ChangeWH(W + deltaW, H + deltaH);
        }

        /// <summary>
        /// Method to clip the shape by a defined width and height.
        /// Assumes the clipping is done with X and Y coordinates as 0.
        /// </summary>
        /// <param name="w">the width of the clipping area</param>
        /// <param name="h">the height of the clipping area</param>
        public void Clip(float w, float h)
        {
            Clip(X, Y, w, h);
        }

        /// <summary>
        /// Method to clip the shape by a defined rectangle area.
        /// </summary>
        /// <param name="x">the X corrdinate for clipping area</param>
        /// <param name="y">the Y coordinate for clipping area</param>
        /// <param name="w">the width of the clipping area</param>
        /// <param name="h">the height of the clipping area</param>
        public void Clip(float x, float y, float w, float h)
        {
            X = Math.Min(Math.Max(x, X), w);
            Y = Math.Min(Math.Max(y, Y), h);
            if (X + W > w) { W = w - X; }
            if (Y + H > h) { H = h - Y; }
        }

        /// <summary>
        /// Method to clip the shape with another shape.
        /// </summary>
        /// <param name="input">the shape to serve as the clipping area</param>
        public void Clip(fRect input)
        {
            Clip(input.X, input.Y, input.W, input.H);
        }

        //
        //  XML
        //  Parsing and Unparsing from and to Xml elements.
        //

        #region Parse/Unparse from/to Xml

        public const string XML_ELM_ROOT = "rect";
        private const string XML_ELM_X = "x";
        private const string XML_ELM_Y = "y";
        private const string XML_ELM_WIDTH = "width";
        private const string XML_ELM_HEIGHT = "height";

        /// <summary>
        /// Parse from a Xml element the definition for a rectangle.
        /// This method will parse the Xml element and build the 
        /// rectangle object instance.
        /// </summary>
        /// <param name="root">the Xml element to parse</param>
        public void ParseFromXml(XElement root)
        {
            root.VerifyName(Config.DEFAULT_XML_NAMESPACE, XML_ELM_ROOT);
            X = (float)root.ParseRequiredChildValue_Double(Config.DEFAULT_XML_NAMESPACE, XML_ELM_X);
            Y = (float)root.ParseRequiredChildValue_Double(Config.DEFAULT_XML_NAMESPACE, XML_ELM_Y);
            W = (float)root.ParseRequiredChildValue_Double(Config.DEFAULT_XML_NAMESPACE, XML_ELM_WIDTH);
            H = (float)root.ParseRequiredChildValue_Double(Config.DEFAULT_XML_NAMESPACE, XML_ELM_HEIGHT);
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
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_X, X));
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_Y, Y));
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_WIDTH, W));
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_HEIGHT, H));
            return root;
        }

        #endregion

        /// <summary>
        /// String representation for the shape instance.
        /// </summary>
        /// <returns>the string representation</returns>
        public override string ToString()
        {
            return "X:" + X + " " + "Y:" + Y + " " + "Width:" + W + " " + "Height:" + H;
        }

        /// <summary>
        /// Clone this shape, returning a new shape.
        /// </summary>
        /// <returns>the new shape</returns>
        public fRect Clone()
        {
            return new fRect(this);
        }
    }
}