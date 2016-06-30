// ============================================================================
// Project: Framework
// Name/Class: dRect
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 17/Oct/2013
// Company: Coop4Creativity
// Description: Double rectangle shape.
// ============================================================================

using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Linq;
using Framework.Core.Extensions;
using Framework.Core.Patterns;

namespace Framework.Drawing.Geom.Shapes
{
    public class dRect : IXmlReady, INotifyPropertyChanged
    {
        //
        // PROPERTIES
        //

        #region Properties

        public double X
        {
            get
            {
                return _X;
            }
            set
            {
                _X = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get
            {
                return _Y;
            }
            set
            {
                _Y = value;
                OnPropertyChanged("Y");
            }
        }

        public double W
        {
            get
            {
                return _W;
            }
            set
            {
                _W = value;
                OnPropertyChanged("W");
            }
        }

        public double H
        {
            get
            {
                return _H;
            }
            set
            {
                _H = value;
                OnPropertyChanged("H");
            }
        }

        #endregion

        //
        // CONSTRUCTORS
        //

        #region Constructors

        //
        //
        // Default constructor. Creates a shape located at (0,0)
        // with 0 set as its width and height.
        //

        public dRect() : this(0, 0, 0, 0) { }

        //
        // Construct a new shape, setting all relevant properties.
        //

        public dRect(double x, double y, double w, double h)
        {
            Change(x, y, w, h);
        }

        //
        // Construct a new rectangle based of an existent rectangle.
        // This constructor will extract the location and size of the 
        // supplied rectangle and build a new one.
        //

        public dRect(dRect shape)
        {
            Change(shape);
        }

        #endregion

        //
        // INSTANCE METHODS
        //

        #region Instance Methods

        //
        // Method to change some of the shape's properties.
        // In this specific case, change the X and Y coordinates.
        //

        public void ChangeXY(double x, double y)
        {
            X = x;
            Y = y;
        }

        //
        // Method to change some of the shape's properties.
        // In this specific case, the width and height for the shape.
        //

        public void ChangeWH(double w, double h)
        {
            W = w;
            H = h;
        }

        //
        // Method to change some of the shape' s properties.
        // In this specific case, the X and Y coordinates, but
        // also the width and height of the shape.
        //

        public void Change(double x, double y, double w, double h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
        }

        //
        // Method to change some of the shape' s properties.
        // Taking a already defined shape. The outcome of this
        // operation is that this shape will have the same values
        // for all its properties as the supplied shape.
        //

        public void Change(dRect shape)
        {
            Change(shape.X, shape.Y, shape.W, shape.H);
        }

        //
        // Shift this shape position in the X and Y axis.
        // Negative values allow the shape to move to left
        // in the X-axis and up in th Y-axis.
        //

        public void Shift(double deltaX, double deltaY)
        {
            ChangeXY(X + deltaX, Y + deltaY);
        }

        //
        // Stretch the shape in a defined width and height. By
        // streching we mean a delta in size, both in width and height.
        // Negative values are allowed.
        //

        public void Stretch(double deltaW, double deltaH)
        {
            ChangeWH(W + deltaW, H + deltaH);
        }

        //
        // Method to clip the shape by a defined width and height.
        // Assumes the clipping is done with X and Y coordinates as
        // the current ones.
        //

        public void Clip(double w, double h)
        {
            Clip(X, Y, w, h);
        }

        //
        // Method to clip the shape by a defined rectangle area.
        //

        public void Clip(double x, double y, double w, double h)
        {
            X = Math.Min(Math.Max(x, X), w);
            Y = Math.Min(Math.Max(y, Y), h);
            if (X + W > w) { W = w - X; }
            if (Y + H > h) { H = h - Y; }
        }

        //
        // Method to clip this shape with another shape.
        //

        public void Clip(dRect input)
        {
            Clip(input.X, input.Y, input.W, input.H);
        }

        //
        // 'Floor' the values found in this dRect.
        // it will return a new rect where the coordinates
        // are integers.
        //

        public dRect Floor()
        {
            int x = Convert.ToInt32(Math.Floor(X));
            int y = Convert.ToInt32(Math.Floor(Y));
            int w = Convert.ToInt32(Math.Floor(W));
            int h = Convert.ToInt32(Math.Floor(H));

            return new dRect(x, y, w, h);
        }

        //
        // 'Ceiling' the values found in this dRect.
        // it will return a new rect where the coordinates
        // are integers.
        //

        public dRect Ceiling()
        {
            int x = Convert.ToInt32(Math.Ceiling(X));
            int y = Convert.ToInt32(Math.Ceiling(Y));
            int w = Convert.ToInt32(Math.Ceiling(W));
            int h = Convert.ToInt32(Math.Ceiling(H));

            return new dRect(x, y, w, h);
        }

        #endregion

        //
        // XML
        // Parsing and Unparsing from and to Xml elements.
        //

        #region Parse/Unparse from/to Xml

        public const string XML_ELM_ROOT = "rect";
        private const string XML_ELM_X = "x";
        private const string XML_ELM_Y = "y";
        private const string XML_ELM_WIDTH = "width";
        private const string XML_ELM_HEIGHT = "height";

        //
        // Parse from a Xml element the definition for a rectangle.
        // This method will parse the Xml element and build the 
        // rectangle object instance.
        //

        public void ParseFromXml(XElement root)
        {
            CultureInfo defaultCult = new CultureInfo("en-us");

            root.VerifyName(Config.DEFAULT_XML_NAMESPACE, XML_ELM_ROOT);

            string strX = root.ParseRequiredChildValue_String(Config.DEFAULT_XML_NAMESPACE, XML_ELM_X);
            string strY = root.ParseRequiredChildValue_String(Config.DEFAULT_XML_NAMESPACE, XML_ELM_Y);
            string strW = root.ParseRequiredChildValue_String(Config.DEFAULT_XML_NAMESPACE, XML_ELM_WIDTH);
            string strH = root.ParseRequiredChildValue_String(Config.DEFAULT_XML_NAMESPACE, XML_ELM_HEIGHT);

            X = strX.ParseRequiredValue_Double(defaultCult);
            Y = strY.ParseRequiredValue_Double(defaultCult);
            W = strW.ParseRequiredValue_Double(defaultCult);
            H = strH.ParseRequiredValue_Double(defaultCult);
        }

        //
        // Unparse the rectangle to a Xml element.
        // This method will unparse this rectangle object
        // instance and generate the Xml definition.
        //

        public XElement UnparseToXml()
        {
            CultureInfo defaultCult = new CultureInfo("en-us");

            XElement root = new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_ROOT);
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_X, X.ToString(defaultCult.NumberFormat)));
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_Y, Y.ToString(defaultCult.NumberFormat)));
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_WIDTH, W.ToString(defaultCult.NumberFormat)));
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_HEIGHT, H.ToString(defaultCult.NumberFormat)));

            return root;
        }

        #endregion

        //
        // TOSTRING
        // String representation for this object.
        //

        public override string ToString()
        {
            return "dRect(X=" + X + ", " + "Y=" + Y + ", " + "W=" + W + ", " + "H=" + H + ")";
        }

        //
        // CLONE
        // Clone this object instance.
        //

        public dRect Clone()
        {
            return new dRect(this);
        }

        //
        // PROPERTY CHANGE NOTIFIER
        // Event for properties changes.
        //

        #region Property Change Notifier

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        //
        // PRIVATE FIELDS
        //

        #region Private Fields

        private double _X = 0.0f;
        private double _Y = 0.0f;
        private double _W = 0.0f;
        private double _H = 0.0f;

        #endregion
    }
}
