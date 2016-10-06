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
    public class dotPort
    {
        /// <summary>
        /// Compass kind for ports
        /// </summary>
        public enum COMPASS_PT
        {
            NONE,
            N,
            NE,
            E,
            SE,
            S,
            SW,
            W,
            NW,
            C,
            UNDERSCORE
        }

        /// <summary>
        /// Port identifier value
        /// </summary>
        public string ID
        {
            get { return __ID; }
            set { __ID = value; }
        }

        /// <summary>
        /// Port compass value
        /// </summary>
        public COMPASS_PT Compass
        {
            get { return __Compass; }
            set { __Compass = value; }
        }

        /// <summary>
        /// Empty constructor
        /// Initializaes internal state at blank
        /// </summary>
        public dotPort()
        {
            ID = string.Empty;
            Compass = COMPASS_PT.NONE;
        }

        // internal storage for public properties
        private string __ID = string.Empty;
        private COMPASS_PT __Compass = COMPASS_PT.NONE;
    }
}
