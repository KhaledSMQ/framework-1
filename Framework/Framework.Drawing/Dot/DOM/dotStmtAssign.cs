// Toolkit Library
// Module : Core :: ADT :: Dot
//
// GraphViz Dot language specification
// 
// Version:1.0
// Date: 12/Jun/2012
// Author(s): João Paulo Carreiro (joao.carreiro@cybermap.pt)

namespace Framework.Drawing.Dot.DOM
{
    public class dotStmtAssign : dotStmt
    {
        /// <summary>
        /// Attribute assign for statement
        /// </summary>
        public dotAttr Assign
        {
            get { return __Assign; }
            set { __Assign = value; }
        }

        /// <summary>
        /// Empty constructor
        /// Initialize internal instance state
        /// </summary>
        public dotStmtAssign()
        {
            Assign = null;
        }

        // internal storage for public properties
        private dotAttr __Assign = null;
    }
}
