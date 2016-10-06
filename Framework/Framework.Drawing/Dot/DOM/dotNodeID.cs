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
    public class dotNodeID
    {
        /// <summary>
        /// Identifier for node
        /// </summary>
        public string ID
        {
            get { return __ID; }
            set { __ID = value; }
        }

        /// <summary>
        /// Port value for node
        /// </summary>
        public dotPort Port
        {
            get { return __Port; }
            set { __Port = value; }
        }

        // internal storage for public properties
        private string __ID = string.Empty;
        private dotPort __Port = null;
    }
}