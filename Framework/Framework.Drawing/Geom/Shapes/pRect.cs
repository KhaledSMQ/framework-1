// Toolkit Library
// Description: C# based library of reusable components and software. 
// Author(s): João Paulo Carreiro (joao.carreiro@cybermap.pt)

using System.ComponentModel;
using System.Xml.Linq;
using Framework.Core.Types.Specialized;
using Framework.Core.Extensions;
using Framework.Core.Patterns;

namespace Framework.Drawing.Geom.Shapes
{
    /// <summary>
    /// Class to model a rectangular shape.
    /// Coordinates are given in percentages.
    /// </summary>
    public class pRect : IXmlReady, INotifyPropertyChanged
    {
        /// <summary>
        /// X-coordinate for the shape.
        /// </summary>
        public Percentage X
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

        /// <summary>
        /// Y-coordinate for the shape.
        /// </summary>
        public Percentage Y
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

        /// <summary>
        /// Width of shape (X-axis).
        /// </summary>
        public Percentage W
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

        /// <summary>
        /// Height of shape (Y-axis)
        /// </summary>
        public Percentage H
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

        /// <summary>
        /// Default constructor. Creates a shape located at (0,0)
        /// with 0 set as its width and height.
        /// </summary>
        public pRect()
        {
            X = new Percentage();
            Y = new Percentage();
            W = new Percentage();
            H = new Percentage();
        }

        /// <summary>
        /// Construct a new shape, setting all relevant properties.
        /// </summary>
        /// <param name="x">the location at the X-axis</param>
        /// <param name="y">the location at the Y-axis</param>
        /// <param name="w">the width for the shape</param>
        /// <param name="h">the height for the shape</param>
        public pRect(Percentage x, Percentage y, Percentage w, Percentage h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
        }

        /// <summary>
        /// Constructor with a defined shape.
        /// Taking a already defined shape. The outcome of this
        /// operation is that this shape will have the same values
        /// for all its properties as the supplied shape.
        /// </summary>
        /// <param name="input">the shape to extract the properties</param>
        public pRect(pRect input)
            : this()
        {
            Change(input);
        }

        /// <summary>
        /// Method to change some of the shape's properties.
        /// In this specific case, change the X and Y coordinates.
        /// </summary>
        /// <param name="x">the new X-coordinate</param>
        /// <param name="y">the new Y-coordinate</param>
        public void ChangeXY(Percentage x, Percentage y)
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
        public void ChangeWH(Percentage w, Percentage h)
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
        public void Change(Percentage x, Percentage y, Percentage w, Percentage h)
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
        /// <param name="input">the shape to extract the properties</param>
        public void Change(pRect input)
        {
            X.Value = input.X.Value;
            Y.Value = input.Y.Value;
            W.Value = input.W.Value;
            H.Value = input.H.Value;
        }

        #region Parse/Unparse to Xml

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
            // verifiy tag
            root.VerifyName(Config.DEFAULT_XML_NAMESPACE, XML_ELM_ROOT);

            // parse coordinates.
            X = root.ParseRequiredChildValue_Percentage(Config.DEFAULT_XML_NAMESPACE, XML_ELM_X);
            Y = root.ParseRequiredChildValue_Percentage(Config.DEFAULT_XML_NAMESPACE, XML_ELM_Y);
            W = root.ParseRequiredChildValue_Percentage(Config.DEFAULT_XML_NAMESPACE, XML_ELM_WIDTH);
            H = root.ParseRequiredChildValue_Percentage(Config.DEFAULT_XML_NAMESPACE, XML_ELM_HEIGHT);
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
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_X, X.ToHuman()));
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_Y, Y.ToHuman()));
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_WIDTH, W.ToHuman()));
            root.Add(new XElement((XNamespace)Config.DEFAULT_XML_NAMESPACE + XML_ELM_HEIGHT, H.ToHuman()));
            return root;
        }

        #endregion

        /// <summary>
        /// String representation for the shape instance.
        /// </summary>
        /// <returns>the string representation</returns>
        public override string ToString()
        {
            return "X:" + X.ToHuman() + " " + "Y:" + Y.ToHuman() + " " + "W:" + W.ToHuman() + " " + "H:" + H.ToHuman();
        }

        /// <summary>
        /// Clone this shape, returning a new shape.
        /// </summary>
        /// <returns>the new shape</returns>
        public pRect Clone()
        {
            return new pRect(this);
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

        private Percentage _X = new Percentage(0.0f);
        private Percentage _Y = new Percentage(0.0f);
        private Percentage _W = new Percentage(0.0f);
        private Percentage _H = new Percentage(0.0f);

        #endregion

    }
}
