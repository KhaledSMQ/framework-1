// ============================================================================
// Project: Framework
// Name/Class: TreeAvl
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Implementation for an AVL tree.
// ============================================================================

using System;
using System.Collections.Generic;
using Framework.Core.Error;

namespace Framework.Core.Collections.Generic
{
    public class TreeAvl<TK, TV> where TK : IComparable
    {
        internal static readonly TreeAvl<TK, TV> Empty = new EmptyAvlTree<TK, TV>();

        //
        // PROPERTIES
        //

        internal virtual TK Key { get; private set; }

        internal virtual TV Value { get; private set; }

        internal virtual TreeAvl<TK, TV> Left { get; private set; }

        internal virtual TreeAvl<TK, TV> Right { get; private set; }

        internal int Height { get; private set; }

        internal virtual bool IsEmpty { get { return false; } }

        //
        // CONSTRUCTORS
        //

        internal TreeAvl() : this(default(TK), default(TV), null, null) { }

        internal TreeAvl(TK key, TV value, TreeAvl<TK, TV> left, TreeAvl<TK, TV> right)
        {
            Key = key;
            Value = value;
            Left = left;
            Right = right;
            Height = 1 + Math.Max(_GetHeight(left), _GetHeight(right));
        }

        //
        // Search for a key in this tree.
        // @return The node that matches the supplied key.
        //

        internal virtual TreeAvl<TK, TV> Search(TK key)
        {
            var compare = key.CompareTo(Key);

            if (compare == 0)
                return this;
            else if (compare > 0)
                return Right.Search(key);
            else
                return Left.Search(key);
        }

        //
        // Add a new node to this tree.
        //

        internal virtual TreeAvl<TK, TV> Add(TK key, TV value)
        {
            var result = default(TreeAvl<TK, TV>);

            if (key.CompareTo(Key) > 0)
                result = new TreeAvl<TK, TV>(Key, Value, Left, Right.Add(key, value));
            else
                result = new TreeAvl<TK, TV>(Key, Value, Left.Add(key, value), Right);

            return _MakeBalanced(result);
        }

        //
        // Remove a key fron this tree.
        //

        internal virtual TreeAvl<TK, TV> Remove(TK key)
        {
            var result = default(TreeAvl<TK, TV>);
            var compare = key.CompareTo(Key);

            if (compare == 0)
            {
                if (Right.IsEmpty && Left.IsEmpty)
                    result = Empty;
                else if (Right.IsEmpty && !Left.IsEmpty)
                    result = Left;
                else if (!Right.IsEmpty && Left.IsEmpty)
                    result = Right;
                else
                {
                    var successor = Right;

                    while (!successor.Left.IsEmpty)
                        successor = successor.Left;

                    result = new TreeAvl<TK, TV>(successor.Key, successor.Value, Left, Right.Remove(successor.Key));
                }
            }
            else if (compare < 0)
                result = new TreeAvl<TK, TV>(Key, Value, Left.Remove(key), Right);
            else
                result = new TreeAvl<TK, TV>(Key, Value, Left, Right.Remove(key));

            return _MakeBalanced(result);
        }

        //
        // Create a enumerablr with the nodes in this tree.
        //

        internal virtual IEnumerable<TreeAvl<TK, TV>> Enumerate()
        {
            var stack = new Stack<TreeAvl<TK, TV>>();

            for (var current = this; !current.IsEmpty || stack.Count > 0; current = current.Right)
            {
                while (!current.IsEmpty)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Peek();
                stack.Pop();
                yield return current;
            }
        }

        //
        // HELPERS
        //

        private static int _GetHeight(TreeAvl<TK, TV> tree)
        {
            return null == tree || tree.IsEmpty ? 0 : tree.Height;
        }

        private static TreeAvl<TK, TV> _RotateLeft(TreeAvl<TK, TV> tree)
        {
            if (tree.Right.IsEmpty)
                return tree;

            return new TreeAvl<TK, TV>(tree.Right.Key, tree.Right.Value,
                new TreeAvl<TK, TV>(tree.Key, tree.Value, tree.Left, tree.Right.Left),
                tree.Right.Right);
        }

        private static TreeAvl<TK, TV> _RotateRight(TreeAvl<TK, TV> tree)
        {
            if (tree.Left.IsEmpty)
                return tree;

            return new TreeAvl<TK, TV>(tree.Left.Key, tree.Left.Value, tree.Left.Left,
                new TreeAvl<TK, TV>(tree.Key, tree.Value, tree.Left.Right, tree.Right));
        }

        private static TreeAvl<TK, TV> _DoubleLeft(TreeAvl<TK, TV> tree)
        {
            if (tree.Right.IsEmpty)
                return tree;

            var rotatedRightChild = new TreeAvl<TK, TV>(tree.Key, tree.Value, tree.Left, _RotateRight(tree.Right));
            return _RotateLeft(rotatedRightChild);
        }

        private static TreeAvl<TK, TV> _DoubleRight(TreeAvl<TK, TV> tree)
        {
            if (tree.Left.IsEmpty)
                return tree;

            var rotatedLeftChild = new TreeAvl<TK, TV>(tree.Key, tree.Value, _RotateLeft(tree.Left), tree.Right);
            return _RotateRight(rotatedLeftChild);
        }

        private static int _Balance(TreeAvl<TK, TV> tree)
        {
            if (tree.IsEmpty)
                return 0;

            return _GetHeight(tree.Right) - _GetHeight(tree.Left);
        }

        private static bool _IsRightHeavy(TreeAvl<TK, TV> tree)
        {
            return _Balance(tree) >= 2;
        }

        private static bool _IsLeftHeavy(TreeAvl<TK, TV> tree)
        {
            return _Balance(tree) <= -2;
        }

        private static TreeAvl<TK, TV> _MakeBalanced(TreeAvl<TK, TV> tree)
        {
            var result = default(TreeAvl<TK, TV>);

            if (_IsRightHeavy(tree))
            {
                if (_IsLeftHeavy(tree.Right))
                    result = _DoubleLeft(tree);
                else
                    result = _RotateLeft(tree);
            }
            else if (_IsLeftHeavy(tree))
            {
                if (_IsRightHeavy(tree.Left))
                    result = _DoubleRight(tree);
                else
                    result = _RotateRight(tree);
            }
            else
                result = tree;

            return result;
        }

        //
        // Empty AVL Tree internal class.
        //

        private sealed class EmptyAvlTree<TK1, TV1> : TreeAvl<TK1, TV1> where TK1 : IComparable
        {
            //
            // PROPERTIES
            //

            internal override TK1 Key
            {
                get { Throw.WithPrefix(Lib.DEFAULT_ERROR_MSG_PREFIX, "AVL tree is empty"); return default(TK1); }
            }

            internal override TV1 Value
            {
                get { Throw.WithPrefix(Lib.DEFAULT_ERROR_MSG_PREFIX, "AVL tree is empty"); return default(TV1); }
            }

            internal override TreeAvl<TK1, TV1> Left
            {
                get { Throw.WithPrefix(Lib.DEFAULT_ERROR_MSG_PREFIX, "AVL tree is empty"); return null; }
            }

            internal override TreeAvl<TK1, TV1> Right
            {
                get { Throw.WithPrefix(Lib.DEFAULT_ERROR_MSG_PREFIX, "AVL tree is empty"); return null; }
            }

            internal override bool IsEmpty
            {
                get { return true; }
            }

            //
            // Add a new node to empty tree.
            //

            internal override TreeAvl<TK1, TV1> Add(TK1 key, TV1 value)
            {
                return new TreeAvl<TK1, TV1>(key, value, this, this);
            }

            //
            // Remove a node from an empty tree. Makes no sense.
            //

            internal override TreeAvl<TK1, TV1> Remove(TK1 key)
            {
                Throw.WithPrefix(Lib.DEFAULT_ERROR_MSG_PREFIX, "AVL tree is empty");
                return null;
            }

            //
            // Search always returns this node,
            //

            internal override TreeAvl<TK1, TV1> Search(TK1 key)
            {
                return this;
            }

            //
            // No enumeration is returned.
            //

            internal override IEnumerable<TreeAvl<TK1, TV1>> Enumerate()
            {
                yield break;
            }
        }
    }
}
