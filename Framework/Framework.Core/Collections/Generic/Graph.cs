// ============================================================================
// Project: Framework
// Name/Class: Graph
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Generic graph implementation with string node identifiers.
// ============================================================================

using System.Collections.Generic;

namespace Framework.Core.Collections.Generic
{
    public class Graph<N, E>
    {
        //
        // Name.
        //

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        //
        // Nodes.
        //

        public SortedDictionary<string, N> Nodes
        {
            get { return _Node; }
        }

        //
        // Edges.
        //

        public SortedDictionary<string, SortedList<string, E>> Edges
        {
            get { return _Edges; }
        }

        //
        // CONSTRUCTORS
        //

        public Graph()
        {
            _Name = string.Empty;
            _Node = new SortedDictionary<string, N>();
            _Edges = new SortedDictionary<string, SortedList<string, E>>();
        }

        //
        // Add a new node to the graph
        //

        public void AddNode(string id, N value)
        {
            if (!string.IsNullOrEmpty(id))
            {
                _Node.Add(id, value);
            }
        }

        //
        // Add a new edge to the graph
        // This should take the inner and destination node identifier and the edge value
        //

        public void AddEdge(string from, string to, E value)
        {
            //
            // standard checks
            //

            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to)) return;

            //
            // check if nodes exist in the graph.
            //

            N fromValue = default(N);
            N toValue = default(N);

            if ((_Node.TryGetValue(from, out fromValue) && _Node.TryGetValue(to, out toValue)))
            {
                SortedList<string, E> adjList = default(SortedList<string, E>);

                if (!_Edges.TryGetValue(from, out adjList))
                {
                    adjList = new SortedList<string, E>();
                }

                adjList.Add(to, value);
            }
        }

        // 
        // PRIVATE FIELDS
        //

        private string _Name = string.Empty;
        private SortedDictionary<string, N> _Node = null;
        private SortedDictionary<string, SortedList<string, E>> _Edges = null;
    }
}
