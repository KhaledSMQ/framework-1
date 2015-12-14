// ============================================================================
// Project: Framework
// Name/Class: AProjection
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 17/Oct/2013
// Company: Cybermap Lta.
// Description: Projection abstract class.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Drawing.Geom.Shapes;
using System.Xml.Linq;

namespace Framework.Drawing.Geom.Projections
{
    public abstract class AProjection : IProjection
    {
        //
        // CONSTRUCTORS
        //

        #region Constructors

        public AProjection()
        {
            __RealSurface = new dRect();
            __VirtualSurface = new dRect();
        }

        #endregion

        //
        //  VIRTUAL SURFACE
        //  Properties & Methods
        //

        #region Virtual Surface Properties & Methods

        //
        // Virtual surface X-axis location value.
        //

        public double VirtualSurfaceX { get { return __VirtualSurface.X; } }

        //
        // Virtual surface Y-axis location value.
        //

        public double VirtualSurfaceY { get { return __VirtualSurface.Y; } }

        //
        // Virtual surface width value.
        //

        public double VirtualSurfaceWidth { get { return __VirtualSurface.W; } }

        //
        // Virtual surface height value.
        //

        public double VirtualSurfaceHeight { get { return __VirtualSurface.H; } }

        //
        // Change the virtual surface definition. 
        // Change the location of X and Y values in the corresponding axis.
        //

        public void ChangeVirtualSurfaceXY(double newX, double newY)
        {
            ChangeVirtualSurface(newX, newY, VirtualSurfaceWidth, VirtualSurfaceHeight);
        }

        //
        // Change the virtual surface definition. 
        // Change the size of  thw width and height values.
        //

        public void ChangeVirtualSurfaceWH(double newW, double newH)
        {
            ChangeVirtualSurface(VirtualSurfaceX, VirtualSurfaceY, newW, newH);
        }

        //
        // Change the virtual surface definition. 
        // Change the location and size, supplying a new shape definition.
        //

        public void ChangeVirtualSurface(dRect newShape)
        {
            ChangeVirtualSurface(newShape.X, newShape.Y, newShape.W, newShape.H);
        }

        //
        // Change the virtual surface definition.
        // Change the location and size of the virtual screen rendering surface.
        //

        public void ChangeVirtualSurface(double newX, double newY, double newW, double newH)
        {
            __VirtualSurface.Change(newX, newY, newW, newH);
            ComputeScales();
        }

        #endregion

        //
        //  REAL SURFACE
        //  Properties & Methods
        //

        #region Real Surface Properties & Methods

        //
        // Real surface X-axis location value.
        //

        public double RealSurfaceX { get { return __RealSurface.X; } }

        //
        // Real surface Y-axis location value.
        //

        public double RealSurfaceY { get { return __RealSurface.Y; } }

        //
        // Real surface width value.
        //

        public double RealSurfaceWidth { get { return __RealSurface.W; } }

        //
        // Real surface height value.
        //

        public double RealSurfaceHeight { get { return __RealSurface.H; } }

        //
        // Change the real surface definition. 
        // Change the location of X and Y values in the corresponding axis.
        //

        public void ChangeRealSurfaceXY(double newX, double newY)
        {
            ChangeRealSurface(newX, newY, RealSurfaceWidth, RealSurfaceHeight);
        }

        //
        // Change the real surface definition. 
        // Change the size of  the width and height values.
        //

        public void ChangeRealSurfaceWH(double newW, double newH)
        {
            ChangeRealSurface(RealSurfaceX, RealSurfaceY, newW, newH);
        }

        //
        // Change the real surface definition. 
        // Change the location and size, supplying a new shape definition.
        //

        public void ChangeRealSurface(dRect newShape)
        {
            ChangeRealSurface(newShape.X, newShape.Y, newShape.W, newShape.H);
        }

        //
        // Change the real surface definition.
        // Change the location and size of the real screen rendering surface.
        //

        public void ChangeRealSurface(double newX, double newY, double newWidth, double newHeight)
        {
            __RealSurface.Change(newX, newY, newWidth, newHeight);
            ComputeScales();
        }

        #endregion

        //
        //  SCALE PROPERTIES & METHODS
        //  Real to Virtual & Virtual to Real.
        //

        #region Scale Properties & Methods

        //
        // Virtual coordinates to real coordinates X scale.
        //

        public double ScaleVirtual2RealX { get { return __VirtualToRealScaleX; } }

        //
        // Virtual coordinates to real coordinates Y scale.
        //

        public double ScaleVirtual2RealY { get { return __VirtualToRealScaleY; } }

        //
        // Real coordinates to virtual coordinates X scale.
        //

        public double ScaleReal2VirtualX { get { return __RealToVirtualScaleX; } }

        //
        // Real coordinates to virtual coordinates Y scale.
        //

        public double ScaleReal2VirtualY { get { return __RealToVirtualScaleY; } }

        //
        // Compute the scale factors between the real screen width and
        // height, and the render screen width and height. This will store
        // the real to virtual, but also the virtual do real scales.
        //

        protected void ComputeScales()
        {
            __RealToVirtualScaleX = (__RealSurface.W != 0) ? __VirtualSurface.W / __RealSurface.W : 0;
            __RealToVirtualScaleY = (__RealSurface.W != 0) ? __VirtualSurface.H / __RealSurface.H : 0;

            __VirtualToRealScaleX = (__VirtualSurface.W != 0) ? __RealSurface.W / __VirtualSurface.W : 0;
            __VirtualToRealScaleY = (__VirtualSurface.H != 0) ? __RealSurface.H / __VirtualSurface.H : 0;
        }

        #endregion

        //
        // PROPORTIONAL ----> REAL
        //

        #region PROPORTIONAL ----> REAL

        public double TransformP2RX(double value)
        {
            return value * __RealSurface.W;
        }

        public double TransformP2RY(double value)
        {
            return value * __RealSurface.H;
        }

        public double TransformP2RW(double value)
        {
            return value * __RealSurface.W;
        }

        public double TransformP2RH(double value)
        {
            return value * __RealSurface.H;
        }

        public void TransformP2RXY(double x, double y, out double outX, out double outY)
        {
            outX = TransformP2RX(x);
            outY = TransformP2RY(y);
        }

        public void TransformP2RWH(double w, double h, out double outW, out double outH)
        {
            outW = TransformP2RW(w);
            outH = TransformP2RH(h);
        }

        public dRect TransformP2R(dRect inShape)
        {
            double x = TransformP2RX(inShape.X);
            double y = TransformP2RY(inShape.Y);
            double w = TransformP2RW(inShape.W);
            double h = TransformP2RH(inShape.H);
            return new dRect(x, y, w, h);
        }

        #endregion

        //
        // PROPORTIONAL ----> VIRTUAL
        //

        #region PROPORTIONAL ----> VIRTUAL

        public double TransformP2VX(double x)
        {
            return x * __VirtualSurface.W;
        }

        public double TransformP2VY(double y)
        {
            return y * __VirtualSurface.H;
        }

        public double TransformP2VW(double w)
        {
            return w * __VirtualSurface.W;
        }

        public double TransformP2VH(double h)
        {
            return h * __VirtualSurface.H;
        }

        public void TransformP2VXY(double x, double y, out double outX, out double outY)
        {
            outX = TransformP2VX(x);
            outY = TransformP2VY(y);
        }

        public void TransformP2VWH(double w, double h, out double outW, out double outH)
        {
            outW = TransformP2VW(w);
            outH = TransformP2VH(h);
        }

        public dRect TransformP2V(dRect inShape)
        {
            double x = TransformP2VX(inShape.X);
            double y = TransformP2VY(inShape.Y);
            double w = TransformP2VW(inShape.W);
            double h = TransformP2VH(inShape.H);
            return new dRect(x, y, w, h);
        }


        #endregion

        //
        // REAL ----> PROPORTIONAL
        //

        #region REAL ----> PROPORTIONAL

        public double TransformR2PX(double value)
        {
            return value / __RealSurface.W;
        }

        public double TransformR2PY(double value)
        {
            return value / __RealSurface.H;
        }

        public double TransformR2PW(double value)
        {
            return value / __RealSurface.W;
        }

        public double TransformR2PH(double value)
        {
            return value / __RealSurface.H;
        }

        public void TransformR2PXY(double x, double y, out double outX, out double outY)
        {
            outX = TransformR2PX(x);
            outY = TransformR2PY(y);
        }

        public void TransformR2PWH(double w, double h, out double outW, out double outH)
        {
            outW = TransformR2PW(w);
            outH = TransformR2PH(h);
        }

        public dRect TransformR2P(dRect inShape)
        {
            double x = TransformR2PX(inShape.X);
            double y = TransformR2PY(inShape.Y);
            double w = TransformR2PW(inShape.W);
            double h = TransformR2PH(inShape.H);
            return new dRect(x, y, w, h);
        }

        #endregion

        //
        // REAL ----> VIRTUAL
        //

        #region REAL ----> VIRTUAL

        public double TransformR2VX(double value)
        {
            return value * __RealToVirtualScaleX;
        }

        public double TransformR2VY(double value)
        {
            return value * __RealToVirtualScaleY;
        }

        public double TransformR2VW(double value)
        {
            return value * __RealToVirtualScaleX;
        }

        public double TransformR2VH(double value)
        {
            return value * __RealToVirtualScaleY;
        }

        public void TransformR2VXY(double x, double y, out double outX, out double outY)
        {
            outX = TransformR2VX(x);
            outY = TransformR2VY(y);
        }

        public void TransformR2VWH(double w, double h, out double outW, out double outH)
        {
            outW = TransformR2VW(w);
            outH = TransformR2VH(h);
        }

        public dRect TransformR2V(dRect inshape)
        {
            double x = TransformR2VX(inshape.X);
            double y = TransformR2VY(inshape.Y);
            double w = TransformR2VW(inshape.W);
            double h = TransformR2VH(inshape.H);
            return new dRect(x, y, w, h);
        }

        #endregion

        //
        // REAL ----> ACTUAL
        //

        #region REAL ----> ACTUAL

        public double TransformR2AX(double value)
        {
            return value + RealSurfaceX;
        }

        public double TransformR2AY(double value)
        {
            return value + RealSurfaceY;
        }

        public double TransformR2AW(double value)
        {
            return value;
        }

        public double TransformR2AH(double value)
        {
            return value;
        }

        public void TransformR2AXY(double x, double y, out double outX, out double outY)
        {
            outX = TransformR2AX(x);
            outY = TransformR2AY(y);
        }

        public void TransformR2AWH(double w, double h, out double outW, out double outH)
        {
            outW = TransformR2AW(w);
            outH = TransformR2AH(h);
        }

        public dRect TransformR2A(dRect shape)
        {
            double x = TransformR2AX(shape.X);
            double y = TransformR2AY(shape.Y);
            double w = TransformR2AW(shape.W);
            double h = TransformR2AH(shape.H);
            return new dRect(x, y, w, h);
        }

        #endregion

        //
        // VIRTUAL ----> PROPORTIONAL
        //

        #region VIRTUAL ----> PROPORTIONAL

        public double TransformV2PX(double x)
        {
            return __VirtualSurface.W == 0.0f ? 0.0f : x / __VirtualSurface.W;
        }

        public double TransformV2PY(double y)
        {
            return __VirtualSurface.H == 0.0f ? 0.0f : y / __VirtualSurface.H;
        }

        public double TransformV2PW(double w)
        {
            return __VirtualSurface.W == 0.0f ? 0.0f : w / __VirtualSurface.W;
        }

        public double TransformV2PH(double h)
        {
            return __VirtualSurface.H == 0.0f ? 0.0f : h / __VirtualSurface.H;
        }

        public void TransformV2PXY(double x, double y, out double outX, out double outY)
        {
            outX = TransformV2PX(x);
            outY = TransformV2PY(y);
        }

        public void TransformV2PWH(double w, double h, out double outW, out double outH)
        {
            outW = TransformV2PW(w);
            outH = TransformV2PH(h);
        }

        public dRect TransformV2P(dRect inShape)
        {
            double x = TransformV2PX(inShape.X);
            double y = TransformV2PY(inShape.Y);
            double w = TransformV2PW(inShape.W);
            double h = TransformV2PH(inShape.H);
            return new dRect(x, y, w, h);
        }

        #endregion

        //
        // VIRTUAL ----> REAL
        //

        #region VIRTUAL ----> REAL

        public double TransformV2RX(double value)
        {
            return value * __VirtualToRealScaleX;
        }

        public double TransformV2RY(double value)
        {
            return value * __VirtualToRealScaleY;
        }

        public double TransformV2RW(double value)
        {
            return value * __VirtualToRealScaleX;
        }

        public double TransformV2RH(double value)
        {
            return value * __VirtualToRealScaleY;
        }

        public void TransformV2RXY(double x, double y, out double outX, out double outY)
        {
            outX = TransformV2RX(x);
            outY = TransformV2RY(y);
        }

        public void TransformV2RWH(double w, double h, out double outW, out double outH)
        {
            outW = TransformV2RW(w);
            outH = TransformV2RH(h);
        }

        public dRect TransformV2R(dRect inShape)
        {
            double x = TransformV2RX(inShape.X);
            double y = TransformV2RY(inShape.Y);
            double w = TransformV2RW(inShape.W);
            double h = TransformV2RH(inShape.H);
            return new dRect(x, y, w, h);
        }

        #endregion

        //
        // VIRTUAL ----> ACTUAL
        //

        #region VIRTUAL ----> ACTUAL

        public double TransformV2AX(double value)
        {
            return value + VirtualSurfaceX;
        }

        public double TransformV2AY(double value)
        {
            return value + VirtualSurfaceY;
        }

        public double TransformV2AW(double value)
        {
            return value;
        }

        public double TransformV2AH(double value)
        {
            return value;
        }

        public void TransformV2AXY(double x, double y, out double outX, out double outY)
        {
            outX = TransformV2AX(x);
            outY = TransformV2AY(y);
        }

        public void TransformV2AWH(double w, double h, out double outW, out double outH)
        {
            outW = TransformV2AW(w);
            outH = TransformV2AH(h);
        }

        public dRect TransformV2A(dRect shape)
        {
            double x = TransformV2AX(shape.X);
            double y = TransformV2AY(shape.Y);
            double w = TransformV2AW(shape.W);
            double h = TransformV2AH(shape.H);
            return new dRect(x, y, w, h);
        }

        #endregion

        //
        // XML
        // Parsing and Unparsing from Xml elements.
        //

        #region Parsing/Unparsing (XML)

        public const string XML_ELM_ROOT = "projection";
        private const string XML_ELM_VIRTUAL_SURFACE = "virtual";
        private const string XML_ELM_REAL_SURFACE = "real";
        private const string XML_ELM_X = "x";
        private const string XML_ELM_Y = "y";
        private const string XML_ELM_WIDTH = "width";
        private const string XML_ELM_HEIGHT = "height";

        //
        // Load configuration data for the view.
        // Method uses the internal workspace object to load from
        // the host system, the configuration for the view to use.
        //

        public void ParseFromXml(XElement elm)
        {
            // 
            // Verify the root element for root element
            //

            elm.VerifyName(Config.DEFAULT_XML_NAMESPACE, XML_ELM_ROOT);

            //
            // Real surface definition. required. parse and set it.
            //

            XElement realSurfaceElm = elm.GetRequiredChild(Config.DEFAULT_XML_NAMESPACE, XML_ELM_REAL_SURFACE);
            double realX = realSurfaceElm.ParseRequiredChildValue_Int(Config.DEFAULT_XML_NAMESPACE, XML_ELM_X);
            double realY = realSurfaceElm.ParseRequiredChildValue_Int(Config.DEFAULT_XML_NAMESPACE, XML_ELM_Y);
            double realW = realSurfaceElm.ParseRequiredChildValue_Int(Config.DEFAULT_XML_NAMESPACE, XML_ELM_WIDTH);
            double realH = realSurfaceElm.ParseRequiredChildValue_Int(Config.DEFAULT_XML_NAMESPACE, XML_ELM_HEIGHT);

            ChangeRealSurface(realX, realY, realW, realH);
        }

        //
        // Save configuration data for the view.
        // Method uses the internal workspace object to save to
        // the host system, the configuration for this view.
        //

        public XElement UnparseToXml()
        {
            //
            // Root element.
            //

            XElement elm = new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_ROOT);

            // 
            // Unparse real surface definition
            //

            XElement real = new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_REAL_SURFACE);
            real.Add(new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_X, RealSurfaceX));
            real.Add(new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_Y, RealSurfaceY));
            real.Add(new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_WIDTH, RealSurfaceWidth));
            real.Add(new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_HEIGHT, RealSurfaceHeight));
            elm.Add(real);

            return elm;
        }

        #endregion

        //
        // STANDARD
        // Standard object methods
        //

        #region Standard

        //
        // String representation of the projection object.
        // Return a textual representation of the projection properties.
        //

        public override string ToString()
        {
            string comma = ", ";
            string str = string.Empty;
            str += "AProjection(";
            str += "Real=(";
            str += "X=" + RealSurfaceX + comma;
            str += "Y=" + RealSurfaceY + comma;
            str += "W=" + RealSurfaceWidth + comma;
            str += "H=" + RealSurfaceHeight + ")" + comma;
            str += "Virtual=(";
            str += "X=" + VirtualSurfaceX + comma;
            str += "Y=" + VirtualSurfaceY + comma;
            str += "W=" + VirtualSurfaceWidth + comma;
            str += "H=" + VirtualSurfaceHeight + ")" + comma;
            str += "Scale R-V=(W=" + ScaleReal2VirtualX + comma + "H=" + ScaleReal2VirtualY + ")" + comma;
            str += "Scale V-R=(W=" + ScaleVirtual2RealX + comma + "H=" + ScaleVirtual2RealY + ")";
            str += ")";
            return str;
        }

        //
        // Clone
        // From interface ICloneable
        //

        public abstract object Clone();

        #endregion

        //
        // PRIVATE FIELDS
        //

        #region Private Fields

        // Real surface shape, i.e. location and size.
        private dRect __RealSurface;

        // Virtual surface shape, i.e. location and size.
        private dRect __VirtualSurface;

        // Real coordinates to virtual coordinates X scale.
        private double __RealToVirtualScaleX;

        // Real coordinates to virtual coordinates Y scale.
        private double __RealToVirtualScaleY;

        // Virtual coordinates to real coordinates X scale.
        private double __VirtualToRealScaleX;

        // Virtual coordinates to real coordinates Y scale.
        private double __VirtualToRealScaleY;

        #endregion
    }
}
