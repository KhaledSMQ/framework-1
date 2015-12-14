using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Drawing.SVG.DOM;
using Framework.Drawing.SVG.DOM.Basic_Shapes;
using Framework.Drawing.SVG.DOM.DataTypes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.IO;

namespace Framework.Drawing.Drawing.SVG.DOM.Image
{
    /// <summary>
    /// Represents a SVG Image.
    /// </summary>
    [SvgElement("image")]
    public class SvgImage : SvgVisualElement
    {
        private Uri _referencedElement;
        private SvgUnit _width;
        private SvgUnit _height;
        private GraphicsPath _path;
        private SvgUnit _x;
        private SvgUnit _y;
        private string _preserve;

        /// <summary>
        /// Initializes a new instance of the <see cref="SvgImage"/> class.
        /// </summary>
        public SvgImage()
        {
            _width = new SvgUnit(0.0f);
            _height = new SvgUnit(0.0f);
        }

        /// <summary>
        /// Gets or sets the uri of the image.
        /// </summary>
        [SvgAttribute("href")]
        public virtual Uri ReferencedElement
        {
            get { return this._referencedElement; }
            set { this._referencedElement = value; }
        }

        /// <summary>
        /// Gets or sets the position where the left point of the image should start.
        /// </summary>
        [SvgAttribute("x")]
        public SvgUnit X
        {
            get { return _x; }
            set
            {
                _x = value;
            }
        }

        /// <summary>
        /// Gets or sets the position where the top point of the image should start.
        /// </summary>
        [SvgAttribute("y")]
        public SvgUnit Y
        {
            get { return _y; }
            set
            {
                _y = value;
            }
        }

        [SvgAttribute("preserveAspectRatio")]
        public string AspectRatio
        {
            get { return _preserve; }
            set { _preserve = value; }
        }

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        [SvgAttribute("width")]
        public SvgUnit Width
        {
            get { return _width; }
            set
            {
                _width = value;
            }
        }

        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        [SvgAttribute("height")]
        public SvgUnit Height
        {
            get { return _height; }
            set
            {
                _height = value;
            }
        }

        /// <summary>
        /// Gets an <see cref="SvgPoint"/> representing the top left point of the rectangle.
        /// </summary>
        public SvgPoint Location
        {
            get { return new SvgPoint(X, Y); }
        }

        /// <summary>
        /// Gets the bounds of the element.
        /// </summary>
        /// <value>The bounds.</value>
        public override RectangleF Bounds
        {
            get { return Path.GetBounds(); }
        }

        /// <summary>
        /// Gets the <see cref="GraphicsPath"/> for this element.
        /// </summary>
        public override GraphicsPath Path
        {
            get
            {
                if (_path == null || IsPathDirty)
                {
                    // If the corners aren't to be rounded just create a rectangle
                    var rectangle = new RectangleF(Location.ToDeviceValue(), new SizeF(Width.ToDeviceValue(), Height.ToDeviceValue()));

                    _path = new GraphicsPath();
                    _path.StartFigure();
                    _path.AddRectangle(rectangle);
                    _path.CloseFigure();
                }

                IsPathDirty = false;
                return _path;
            }
        }


        /// <summary>
        /// Renders the <see cref="SvgElement"/> and contents to the specified <see cref="Graphics"/> object.
        /// </summary>
        protected override void Render(SvgRenderer renderer)
        {
            if (Width.Value > 0.0f || Height.Value > 0.0f)
            {

                WebClient wc = new WebClient();
                System.Drawing.Image img = System.Drawing.Image.FromStream(wc.OpenRead(this.ReferencedElement));
                renderer.DrawImage(img, this.X, this.Y, this.Width, this.Height);
            }
        }
    }
}
