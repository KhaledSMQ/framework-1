// ============================================================================
// Project: Framework
// Name/Class: TreeNode
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Generic tree node collection.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Core.Collections.Generic
{
    public class TreeNode<T> : ITreeNode<T>
    {
        //
        // PROPERTIES
        // 

        public T Info { get; set; }

        public IList<ITreeNode<T>> Children { get; set; }

        //
        // Returns true if node is a leaf node.
        // Leaf nodes have no children.
        //

        public bool IsLeaf
        {
            get { return 0 == this.Children.Count; }
        }

        //
        // CONSTRUCTORS
        //

        public TreeNode(T info, IList<ITreeNode<T>> children)
        {
            Info = info;
            Children = children;
        }

        public TreeNode(T info) : this(info, new List<ITreeNode<T>>()) { }

        public TreeNode() : this(default(T)) { }

        //
        // MAPPING FUNCTION
        //

        public ITreeNode<O> Map<O>(Func<T, object, O> mapDelegate, object accum = null)
        {
            return _MapRec<O>(mapDelegate, accum);
        }

        private ITreeNode<O> _MapRec<O>(Func<T, object, O> mapDelegate, object accum)
        {
            TreeNode<O> output = new TreeNode<O>(mapDelegate(this.Info, accum));
            this.Children.Apply<ITreeNode<T>>(node => { output.Children.Add(((TreeNode<T>)node)._MapRec<O>(mapDelegate, accum)); });
            return output;
        }

        //
        // CATAMORPHISM
        //

        public O Cata<O>(Func<T, object, O> emptyDelegate, Func<T, IList<O>, object, O> consDelegate, object accum = null)
        {
            return _CataRec(emptyDelegate, consDelegate, accum);
        }

        private O _CataRec<O>(Func<T, object, O> emptyDelegate, Func<T, IList<O>, object, O> consDelegate, object accum = null)
        {
            O output = default(O);

            if (IsLeaf)
            {
                output = emptyDelegate(this.Info, accum);
            }
            else
            {
                IList<O> childrenOutput = new List<O>();
                this.Children.Apply<ITreeNode<T>>(node =>
                {
                    childrenOutput.Add(((TreeNode<T>)node)._CataRec<O>(emptyDelegate, consDelegate, accum));
                });

                output = consDelegate(this.Info, childrenOutput, accum);
            }

            return output;
        }

        //
        // TOSTRING
        //

        public override string ToString()
        {
            return this.GetType().Name + "(Info=" + Info + ", Children=" + Children.UnparseToString("[", "]", ",") + ")";
        }

        //
        // Print Visual Tree
        //

        public string ToVisualTree()
        {
            levels.Clear();

            if (this == null || Children.Count == 0)
            {
                return string.Empty;
            }

            string outputString = string.Empty;
            _GetVisualTree(ref outputString);
            return outputString;
        }

        //
        // Checks if this tree is equal to the one given.
        // Returns true if they're equal, false if not.
        //

        public override bool Equals(object obj)
        {
            bool output = true;

            if ((null == obj) || (!(obj is TreeNode<T>)))
            {
                output = false;
            }
            else
            {
                TreeNode<T> otherNode = null;
                otherNode = obj as TreeNode<T>;

                output = (Info.Equals(otherNode.Info)) && (Children.Count == otherNode.Children.Count);

                for (int i = 0; output && i < Children.Count; ++i)
                {
                    output = Children[i].Equals(otherNode.Children[i]);
                }
            }

            return output;
        }

        //
        // This prevents the warning that we are overriding the 
        // Equals method but not the GetHashCode
        //

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //
        // HELPERS
        //

        private void _GetVisualTree(ref string outputString, int level = 0)
        {
            char pad = ' ';

            if (level == 0)
            {
                outputString += Info.ToString() + "\n";
            }
            else
            {
                string thisNodeString = string.Empty;

                for (int i = 1; i <= level; ++i)
                {
                    thisNodeString = thisNodeString.PadRight(i * 2, pad);
                    if (level == i || levels.Count > i - 1 && levels[i - 1].Value)
                    {
                        thisNodeString += "|";
                    }
                }

                outputString += thisNodeString + "-" + Info.ToString() + "\n";

                if (IsLeaf)
                {
                    thisNodeString = string.Empty;
                    for (int i = 1; i <= level; ++i)
                    {
                        thisNodeString = thisNodeString.PadRight(i * 2, pad);
                        if (levels.Count > i - 1 && levels[i - 1].Value)
                        {
                            thisNodeString += "|";
                        }
                    }
                    outputString += thisNodeString + "\n";
                }
            }

            foreach (TreeNode<T> node in Children)
            {
                ++level;
                levels.Add(new KeyValuePair<int, bool>(level, node != Children.Last()));
                node._GetVisualTree(ref outputString, level);
                levels.Remove(levels.Last());
                --level;
            }
        }

        //
        // PRIVATE FIELDS
        //

        static private List<KeyValuePair<int, bool>> levels = new List<KeyValuePair<int, bool>>();
    }
}
