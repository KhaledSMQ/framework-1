using System.Collections.Generic;

namespace Framework.Drawing.Dot.DOM
{
    public class dotGraph
    {
        public enum KIND
        {
            SUBGRAPH,
            GRAPH,
            DIGRAPH
        }

        //
        // PROPERTIES
        //

        public string ID
        {
            get { return __ID; }
            set { __ID = value; }
        }

        public KIND Kind
        {
            get { return __Kind; }
            set { __Kind = value; }
        }

        public List<dotStmt> Stmts
        {
            get { return __Stmts; }
            set { __Stmts = value; }
        }


        public bool Strict
        {
            get { return __Strict; }
            set { __Strict = value; }
        }

        /// <summary>
        /// Empty constructor for graph
        /// </summary>
        public dotGraph()
        {
            Stmts = new List<dotStmt>();
        }

        // internal storage for public properties
        private string __ID = string.Empty;
        private List<dotStmt> __Stmts = default(List<dotStmt>);
        private bool __Strict = false;
        private dotGraph.KIND __Kind;
    }
}
