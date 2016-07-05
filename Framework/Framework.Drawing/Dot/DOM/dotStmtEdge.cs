// Toolkit Library
// Module : Core :: ADT :: Dot
//
// GraphViz Dot language specification
// 
// Version:1.0
// Date: 12/Jun/2012
// Author(s): João Paulo Carreiro (joaopaulocarreiro@gmail.com)

using System.Collections.Generic;

namespace Framework.Drawing.Dot.DOM
{
    public class dotStmtEdge : dotStmt
    {
        /// <summary>
        /// List of statement edges
        /// </summary>
        public List<dotNodeID> Nodes
        {
            get { return __Nodes; }
            set { __Nodes = value; }
        }

        /// <summary>
        /// List of statement attributes
        /// </summary>
        public List<dotAttr> Attrs
        {
            get { return __Attrs; }
            set { __Attrs = value; }
        }

        /// <summary>
        /// Empty constructor
        /// Initialize internal state for instance
        /// </summary>
        public dotStmtEdge()
        {
            Nodes = new List<dotNodeID>();
            Attrs = new List<dotAttr>();
        }

        // internal storage for public properties
        private List<dotNodeID> __Nodes = null;
        private List<dotAttr> __Attrs = null;
    }
}
