// ============================================================================
// Project: Framework
// Name/Class: ILayout
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 17/Oct/2013
// Company: Coop4Creativity
// Description: Layout interface implementation.
// ============================================================================

using System.Collections.Generic;
using Framework.Core.Patterns;
using Framework.Drawing.Geom.Projections;
using Framework.Drawing.Geom.Shapes;

namespace Framework.Drawing.Geom.Layouts
{
    public interface ILayout : IKey<string>, IDictionary<string, IRegion>, IXmlReady
    {
        /// <summary>
        /// Name for layout. Required value.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Description for layout. Optional value.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Location for the file that contains this layout. Required value.
        /// </summary>
        string Uri { get; set; }

        /// <summary>
        /// Method to compute the real shape for the layout.
        /// This method should apply the projection to all regions
        /// of the layout, setting its real shape property.
        /// </summary>
        /// <param name="projection">the projection to use</param>
        void ComputeRealShape(IProjectionP2R projection);

        /// <summary>
        /// Transform the list of region identifiers into a list of real shapes.
        /// This method will get the shapes of the regions with the defined identifiers.
        /// </summary>
        /// <param name="lst">the list of  window identifiers</param>
        /// <returns>the list of associated shapes for the region identifiers</returns>
        IList<dRect> GetRealShapes(IList<string> lst);

        /// <summary>
        /// Transform the list of region identifiers into a list of proportional shapes.
        /// This method will get the shapes of the regions with the defined identifiers.
        /// </summary>
        /// <param name="lst">the list of  window identifiers</param>
        /// <returns>the list of associated shapes for the region identifiers</returns>
        IList<dRect> GetProportionalShapes(IList<string> lst);

        /// <summary>
        /// Load from a Uri a layout definition. This method will load
        /// from the uri a specific file (set in the Uri property)
        /// and parse it, building the internal representation for the
        /// layout properties.
        /// </summary>
        void Load(string uri);

        /// <summary>
        /// Save the layout information to a Uri. This method will take
        /// all the properties found in this layout object instance and
        /// save them to a file in the specified Uri.
        /// <param name="uri">the uri where to save the file</param>
        /// </summary>
        void Save(string uri);

        /// <summary>
        /// Save the layout information to a Uri. This method will take
        /// all the properties found in this layout object instance and
        /// save them to a file in the specified Uri.
        /// </summary>
        void Save();
    }
}
