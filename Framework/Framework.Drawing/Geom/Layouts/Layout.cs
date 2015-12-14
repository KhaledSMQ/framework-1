// ============================================================================
// Project: Framework
// Name/Class: Layout
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 17/Oct/2013
// Company: Cybermap Lta.
// Description: Layout concrete class. Layouts are sets of regions.
// ============================================================================

using Framework.Core.Collections.Generic;
using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Drawing.Geom.Projections;
using Framework.Drawing.Geom.Shapes;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Framework.Drawing.Geom.Layouts
{
    public class Layout : ObservableGenericMap<string, IRegion>, ILayout
    {
        //
        // Unique identifier for layout.
        //

        public string Key { get; set; }

        // 
        // Name for layout. Required value.
        //

        public string Name { get; set; }

        //
        // Location for the file that contains this layout. Required value.
        //

        public string Uri { get; set; }

        //
        // Description for layout. Optional value.
        //

        public string Description { get; set; }

        //
        // Key generator for included regions.
        //

        public IKeyGenerator<string> KeyGenerator { get; set; }

        /// <summary>
        /// Constructor for a layout instance.
        /// Initialize the inner structures for layout.
        /// </summary>
        public Layout()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        /// <summary>
        /// Compute the real shape for this layout. Compute the real shape
        /// for the layouts means computing the real shape for all regions.
        /// </summary>
        /// <param name="projection">the projection to use</param>
        public void ComputeRealShape(IProjectionP2R projection)
        {
            ValuesAsList().Apply<IRegion>(r => r.ComputeRealShape(projection));
        }

        /// <summary>
        /// Transform the list of region identifiers into a list of real shapes.
        /// This method will get the shapes of the regions with the defined identifiers.
        /// </summary>
        /// <param name="lst">the list of  window identifiers</param>
        /// <returns>the list of associated shapes for the region identifiers</returns>
        public IList<dRect> GetRealShapes(IList<string> lst)
        {
            IList<dRect> output = new List<dRect>();
            foreach (string key in lst) { output.Add(GetRequired(key).RealShape); }
            return output;
        }

        /// <summary>
        /// Transform the list of region identifiers into a list of proportional shapes.
        /// This method will get the shapes of the regions with the defined identifiers.
        /// </summary>
        /// <param name="lst">the list of  window identifiers</param>
        /// <returns>the list of associated shapes for the region identifiers</returns>
        public IList<dRect> GetProportionalShapes(IList<string> lst)
        {
            IList<dRect> output = new List<dRect>();
            foreach (string key in lst) { output.Add(GetRequired(key).ProportionalShape); }
            return output;
        }

        /// <summary>
        /// Load from a file a layout definition. This method will load
        /// from the host system a specific file (set in the constructor)
        /// and parse it, building the internal representation for the
        /// layout properties.
        /// </summary>
        public void Load(string uri)
        {
            // load file and parse it
            Uri = uri;
            ParseFromXml(XDocument.Load(Uri).Root);
        }


        /// <summary>
        /// Save the layout information to a file. This method will take
        /// all the properties found in this layout object instance and
        /// save them to a file in the host system.
        /// <param name="uri">the uri where to save the file</param>
        /// </summary>
        public void Save(string uri)
        {
            // save document to host system
            XDocument doc = new XDocument(UnparseToXml());
            doc.Save(uri);
        }

        /// <summary>
        /// Save the layout information to a file. This method will take
        /// all the properties found in this layout object instance and
        /// save them to a file in the host system.
        /// </summary>
        public void Save()
        {
            Save(Uri);
        }

        //
        //  XML
        //  Parsing and Unparsing from and to Xml elements.
        //

        #region Parse/Unparse to Xml

        // Xml parsing and unparsing settings
        public const string XML_ELM_ROOT = "layout";
        private const string XML_ELM_KEY = "key";
        private const string XML_ELM_NAME = "name";
        private const string XML_ELM_DESCRIPTION = "description";
        private const string XML_ELM_REGIONS = "regions";

        /// <summary>
        /// Parse from a Xml element the definition for a layout.
        /// This method will parse the Xml element and build the 
        /// layout object instance.
        /// </summary>
        /// <param name="root">the XMl element to parse</param>
        public void ParseFromXml(XElement root)
        {
            // clear all values found in this layout
            Clear();

            // verifiy tag, parse key, name & description
            root.VerifyName(Config.DEFAULT_XML_NAMESPACE, XML_ELM_ROOT);
            Key = root.ParseOptionalChildValue_String(Config.DEFAULT_XML_NAMESPACE, XML_ELM_KEY, string.Empty);
            Name = root.ParseRequiredChildValue_String(Config.DEFAULT_XML_NAMESPACE, XML_ELM_NAME);
            Description = root.ParseOptionalChildValue_String(Config.DEFAULT_XML_NAMESPACE, XML_ELM_DESCRIPTION, string.Empty);

            // list of regions
            XElement regions = root.GetRequiredChild(Config.DEFAULT_XML_NAMESPACE, XML_ELM_REGIONS);
            foreach (XElement child in regions.Elements(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + Region.XML_ELM_ROOT))
            {
                Region region = new Region();
                region.ParseFromXml(child);

                // check the name of the region, if no name is 
                // supplied, then we need to generate one.
                if (region.Name.isNullOrEmpty())
                {
                    region.Name = KeyGenerator.GetKey();
                }

                // add the region to the set of regions.
                Register(region.Name, region);
            }
        }

        /// <summary>
        /// Unparse the layout to a Xml element.
        /// This method will unparse this layout object
        /// instance and generate the Xml definition.
        /// </summary>
        /// <returns>the Xml element the corresponds to this layout object instance</returns>
        public XElement UnparseToXml()
        {
            // root, name & description
            XElement root = new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_ROOT);
            root.Add(new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_NAME, Name));
            root.Add(new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_DESCRIPTION, Description));

            // list of regions
            if (Count > 0)
            {
                XElement regions = new XElement(((XNamespace)Config.DEFAULT_XML_NAMESPACE) + XML_ELM_REGIONS);
                root.Add(regions);
                foreach (Region region in Values)
                {
                    regions.Add(region.UnparseToXml());
                }
            }

            return root;
        }

        #endregion

        /// <summary>
        /// String representation for the layout instance.
        /// </summary>
        /// <returns>the string representation of the layout instance</returns>
        public override string ToString()
        {
            string tab = "  ";
            string nl = System.Environment.NewLine;
            string str = string.Empty;
            str += "Layout:" + nl;
            str += tab + "Name........:" + Name + nl;
            str += tab + "Description.:" + Description + nl;
            str += tab + "Regions.....:" + nl;
            str += ValuesAsList().UnparseToString(tab + tab, nl, nl + tab + tab);
            return str;
        }
    }
}
