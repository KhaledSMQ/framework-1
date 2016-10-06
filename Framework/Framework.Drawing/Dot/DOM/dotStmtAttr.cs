// Toolkit Library
// Module : Core :: ADT :: Dot
//
// GraphViz Dot language specification
// 
// Version:1.0
// Date: 12/Jun/2012
// Author(s): João Paulo Carreiro (joao.carreiro@coop4creativity.com)

using System.Collections.Generic;

namespace Framework.Drawing.Dot.DOM
{
    public class dotStmtAttr : dotStmt
    {
        /// <summary>
        /// Source for attribute statement
        /// </summary>
        public enum KIND
        {
            GRAPH,
            NODE,
            EDGE
        }

        /// <summary>
        /// Source of attribute statement value
        /// </summary>
        public KIND Kind
        {
            get { return __Kind; }
            set { __Kind = value; }
        }

        /// <summary>
        /// List of attributes
        /// </summary>
        public List<dotAttr> Attrs
        {
            get { return __Attrs; }
            set { __Attrs = value; }
        }

        /// <summary>
        /// Empty constructor
        /// Initialize internal state for attribute statement
        /// </summary>
        public dotStmtAttr()
        {
            Attrs = new List<dotAttr>();
        }

        // internal storage for public properties
        private KIND __Kind;
        private List<dotAttr> __Attrs;
    }
}
