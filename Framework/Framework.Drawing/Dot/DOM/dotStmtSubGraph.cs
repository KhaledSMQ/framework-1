// Toolkit Library
// Module : Core :: ADT :: Dot
//
// GraphViz Dot language specification
// 
// Version:1.0
// Date: 12/Jun/2012
// Author(s): João Paulo Carreiro (joao.carreiro@coop4creativity.com)

namespace Framework.Drawing.Dot.DOM
{
    public class dotStmtSubGraph : dotStmt
    {
        /// <summary>
        /// Subgraph specification
        /// </summary>
        public dotGraph Graph
        {
            get { return __Graph; }
            set { __Graph = value; }
        }

        /// <summary>
        /// Empty constructor
        /// Initialize internal state instance
        /// </summary>
        public dotStmtSubGraph()
        {
            Graph = null;
        }

        // internal storage for public properties
        private dotGraph __Graph = null;
    }
}
