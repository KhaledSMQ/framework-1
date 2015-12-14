// Toolkit Library
// Module : Core :: ADT :: Dot
//
// GraphViz Dot language specification
// 
// Version:1.0
// Date: 12/Jun/2012
// Author(s): João Paulo Carreiro (joao.carreiro@cybermap.pt)

using System.Collections.Generic;

namespace Framework.Drawing.Dot.DOM
{
    public class dotStmtNode : dotStmt
    {
        /// <summary>
        /// Node identifier
        /// </summary>
        public dotNodeID NodeID
        {
            get { return __NodeID; }
            set { __NodeID = value; }
        }

        /// <summary>
        /// List of attributes for node statement
        /// </summary>
        public List<dotAttr> Attrs
        {
            get { return __Assigns; }
            set { __Assigns = value; }
        }

        /// <summary>
        /// Empty constructor
        /// Initialize internal state for instance
        /// </summary>
        public dotStmtNode()
        {
            Attrs = new List<dotAttr>();
        }

        // internal storage for public properties
        private dotNodeID __NodeID = null;
        private List<dotAttr> __Assigns = null;
    }
}
