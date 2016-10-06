// ============================================================================
// Project: Framework
// Name/Class: DictAvl
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Dictionary implemented as an AVL tree.
// ============================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core.Collections.Generic
{
    //
    // TODO:
    // Implement IDictionary interface.
    //

    public class DictAvl<TK, TV> : IEnumerable<TV> where TK : IComparable
    {
        //
        // PROPERTIES
        //

        public int Length { get { return _AvlTree.Enumerate().Count(); } }

        //
        // CONSTRUCTORS
        //

        internal DictAvl(TreeAvl<TK, TV> tree)
        {
            _AvlTree = tree;
        }

        public DictAvl<TK, TV> Add(TK key, TV value)
        {
            return new DictAvl<TK, TV>(_AvlTree.Add(key, value));
        }

        public DictAvl<TK, TV> Remove(TK key)
        {
            return new DictAvl<TK, TV>(_AvlTree.Remove(key));
        }

        public bool Contains(TK key)
        {
            return !_AvlTree.Search(key).IsEmpty;
        }

        public IEnumerator<TV> GetEnumerator()
        {
            foreach (var kv in _AvlTree.Enumerate())
                yield return kv.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<TV>)this).GetEnumerator();
        }

        protected string Show()
        {

            var sb = new StringBuilder();
            sb.Append("map");
            sb.Append('{');
            var c = 0;

            foreach (var e in _AvlTree.Enumerate())
            {
                if (c++ > 0)
                    sb.Append(',');

                sb.Append(e.Key.ToString());
                sb.Append('=');
                sb.Append(e.Value.ToString());
            }

            sb.Append('}');
            return sb.ToString();
        }

        //
        // PRIVATE FIELDS
        //

        private TreeAvl<TK, TV> _AvlTree;
        private static readonly DictAvl<TK, TV> Empty = new DictAvl<TK, TV>(TreeAvl<TK, TV>.Empty);
    }
}
