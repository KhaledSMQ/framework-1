// ============================================================================
// Project: Framework
// Name/Class: IRegion
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 17/Oct/2013
// Company: Cybermap Lta.
// Description: Region interface.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Drawing.Geom.Projections;
using Framework.Drawing.Geom.Shapes;

namespace Framework.Drawing.Geom.Layouts
{
    public interface IRegion : IXmlReady
    {
        /// <summary>
        /// The name for the region. Optional value.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The description for the region. Optional value.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// The proprtional shape for the region.
        /// </summary>
        dRect ProportionalShape { get; set; }

        /// <summary>
        /// The real shape for the region. 
        /// </summary>
        dRect RealShape { get; set; }

        /// <summary>
        /// Method to compute the real shape for the region.
        /// This method should apply the projection to the region
        /// shape, setting its real shape property with the proper values.
        /// </summary>
        /// <param name="projection">the projection to use</param>
        void ComputeRealShape(IProjectionP2R projection);
    }
}
