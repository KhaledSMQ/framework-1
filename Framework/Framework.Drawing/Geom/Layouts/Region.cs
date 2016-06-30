// ============================================================================
// Project: Framework
// Name/Class: Region
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 17/Oct/2013
// Company: Coop4Creativity
// Description: Region concrete class.
// ============================================================================

using System.Xml.Linq;
using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Drawing.Geom.Projections;
using Framework.Drawing.Geom.Shapes;

namespace Framework.Drawing.Geom.Layouts
{
    public class Region : IRegion, IXmlReady
    {
        /// <summary>
        /// Name for region. Optional value. 
        /// No two regions in the same layout 
        /// can have the same name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description for region. Optional value.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Proportional shape for region. Shape given in
        /// percentage values.
        /// </summary>
        public dRect ProportionalShape { get; set; }

        /// <summary>
        /// Real shape for the region. Values included
        /// are the real, actual values for the region.
        /// </summary>
        public dRect RealShape { get; set; }

        /// <summary>
        /// Default constructor. Initialize region with
        /// empty property values.
        /// </summary>
        public Region()
        {
            Name = string.Empty;
            Description = string.Empty;
            RealShape = new dRect();
            ProportionalShape = new dRect();
        }

        /// <summary>
        /// Create a new region based on another 
        /// region, this is useful for cloning objects.
        /// </summary>
        /// <param name="region">the region object instance</param>
        public Region(Region region)
        {
            Name = region.Name;
            Description = region.Description;
            RealShape = region.RealShape.Clone();
            ProportionalShape = region.ProportionalShape.Clone();
        }

        /// <summary>
        /// Compute the real shape of the region. In order to perform this 
        /// computation, we need a projection from proportional to real
        /// coordinates.
        /// </summary>
        /// <param name="projection">the projection to use</param>
        public void ComputeRealShape(IProjectionP2R projection)
        {
            RealShape = projection.TransformP2R(ProportionalShape);
        }

        //
        //  XML
        //  Parsing and Unparsing from and to Xml elements.
        //

        #region Parse/Unparse from/to Xml

        // Xml parsing and unparsing settings
        public const string XML_ELM_ROOT = "region";
        private const string XML_ELM_NAME = "name";
        private const string XML_ELM_DESCRIPTION = "description";

        /// <summary>
        /// Parse from a Xml element the definition of a region.
        /// A region is basically a name and a shape (rectangular)
        /// region. This method will parse from the Xml these properties.
        /// </summary>
        /// <param name="root">the Xml element to parse</param>
        public void ParseFromXml(XElement root)
        {
            root.VerifyName(Config.DEFAULT_XML_NAMESPACE, XML_ELM_ROOT);
            Name = root.ParseOptionalChildValue_String(Config.DEFAULT_XML_NAMESPACE, XML_ELM_NAME, string.Empty);
            Description = root.ParseOptionalChildValue_String(Config.DEFAULT_XML_NAMESPACE, XML_ELM_DESCRIPTION, string.Empty);
            ProportionalShape.ParseFromXml(root.GetRequiredChild(Config.DEFAULT_XML_NAMESPACE, pRect.XML_ELM_ROOT));
        }

        /// <summary>
        /// Unparse the a region object instance to a Xml instance.
        /// This method create a Xml object instance from this objects properties.
        /// </summary>
        /// <returns>the Xml element that corresponds to this region object instance</returns>
        public XElement UnparseToXml()
        {
            XElement root = new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_ROOT);
            root.Add(new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_NAME, Name));
            root.Add(new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_DESCRIPTION, Description));
            root.Add(ProportionalShape.UnparseToXml());
            return root;
        }

        #endregion

        /// <summary>
        /// String representation for the region object instance.
        /// </summary>
        /// <returns>the string representation of the region instance</returns>
        public override string ToString()
        {
            string tab = "  ";
            string nl = System.Environment.NewLine;
            string str = string.Empty;
            str += "Region:" + nl;
            str += tab + "Name........:" + Name + nl;
            str += tab + "Description.:" + Description + nl;
            str += tab + "Shape[P]....:" + ProportionalShape + nl;
            str += tab + "Shape[R]....:" + RealShape + nl;
            return str;
        }

        /// <summary>
        /// Clone a region. Return a new region but with their internal properties 
        /// set with the same values as this one.
        /// </summary>
        /// <returns>the cloned region object instance</returns>
        public Region Clone()
        {
            return new Region(this);
        }
    }
}
