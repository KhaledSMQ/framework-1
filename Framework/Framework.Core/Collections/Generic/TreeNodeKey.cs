// ============================================================================
// Project: Framework
// Name/Class: TreeNodeKey
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: This class models generic trees indexed with a key. Keys
//              can be any hashable object class. We also include methods
//              for generating Xml representations.
// ============================================================================

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Framework.Core.Patterns;

namespace Framework.Core.Collections.Generic
{
    public class TreeNodeKey<K, T>
    {
        //
        // Key value stored in the tree node
        //

        public K Key
        {
            get { return _Key; }
            set { _Key = value; }
        }

        //
        // Information stored in the tree node
        //

        public T Info
        {
            get { return _Info; }
            set { _Info = value; }
        }

        //
        // Return true if node does not have children, false otherwise
        //

        public bool IsLeaf
        {
            get { return Children.Count == 0; }
        }

        //
        // Indexed children list of tree nodes
        //

        public SortedDictionary<K, TreeNodeKey<K, T>> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }

        //
        // List of children nodes, ordered by insertion
        //

        public List<TreeNodeKey<K, T>> OrderedChildren
        {
            get { return _OrderedChildren; }
            set { _OrderedChildren = value; }
        }

        //
        // Empty constructor for tree nodes
        // Public properties are set will default values
        //

        public TreeNodeKey() : this(default(K), default(T)) { }

        //
        // Create a new tree node, setting all the 
        // public properties with an initial value.
        // Children nodes starts with an empty list
        //

        public TreeNodeKey(K key, T info)
        {
            Key = key;
            Info = info;
            Children = new SortedDictionary<K, TreeNodeKey<K, T>>();
            OrderedChildren = new List<TreeNodeKey<K, T>>();
        }

        //
        // Add a new node to the children of this node
        //

        public void Add(TreeNodeKey<K, T> node)
        {
            if (!Children.ContainsKey(node.Key))
            {
                Children.Add(node.Key, node);
                OrderedChildren.Add(node);
            }
            else
            {
                throw new Exception("key '" + node.Key + "' already exists in the tree node key");
            }
        }

        //
        // Insert nultiple nodes with diferent categories but same value
        //

        public void InsertMultiple(K[][] paths, T value, Func<K, T, T> folderDelegate, Func<K, T, T> leafDelegate, Func<int, K> newKeyDelegate)
        {
            foreach (K[] path in paths)
            {
                Insert(path, value, folderDelegate, leafDelegate, newKeyDelegate);
            }
        }

        //
        // Insert a new node, creating the path in the tree, if it does not exist
        //

        public void Insert(K[] path, T value, Func<K, T, T> folderDelegate, Func<K, T, T> leafDelegate, Func<int, K> newKeyDelegate)
        {
            int i = 0;
            int j = 0;
            TreeNodeKey<K, T> node = null;
            SortedDictionary<K, TreeNodeKey<K, T>> sons = null;

            // 
            // Start algorithm
            //

            node = this;
            sons = node.Children;

            // 
            // Find the node where to insert the value
            //

            for (i = 0; i < path.Length && sons.ContainsKey(path[i]); i++)
            {
                node = sons[path[i]];
                sons = node.Children;
            }

            //
            // Insert the number of nodes necessary to finish
            // the intended tree structure, if the node where to
            // insert is not valid we dont insert it
            //

            if (null != node)
            {
                for (j = i; j < path.Length - 1; j++)
                {
                    TreeNodeKey<K, T> folderNode = new TreeNodeKey<K, T>(path[j], folderDelegate(path[j], value));
                    node.Add(folderNode);
                    node = folderNode;
                }
            }

            //
            // Finally insert the value, we test the value of the leaf delegate,
            // because we want the user to be able to set it to null, effectivaly
            // generating a tree who nodes are simply the folders, useful for 
            // generating tree category nodes.
            //

            if ((null != node) && (null != leafDelegate))
            {
                K nextKey = path[j];
                TreeNodeKey<K, T> leafNode = new TreeNodeKey<K, T>(nextKey, leafDelegate(nextKey, value));
                node.Add(leafNode);
            }
        }

        public void InsertMultipleLeaf(K[][] paths, T value, Func<K, T, T> folderDelegate, Func<T, T> leafDelegate, IKeyGenerator<K> keyGen)
        {
            foreach (K[] path in paths)
            {
                InsertLeaf(path, value, folderDelegate, leafDelegate, keyGen);
            }
        }

        //
        // Insert a new value starting in this tree node. Inserts all the values found in the supplied
        // path if they do not already exist. After this, it will insert the node leaf.
        //

        public void InsertLeaf(K[] path, T value, Func<K, T, T> folderDelegate, Func<T, T> leafDelegate, IKeyGenerator<K> keyGen)
        {
            int i = 0;
            int j = 0;
            TreeNodeKey<K, T> node = null;
            SortedDictionary<K, TreeNodeKey<K, T>> sons = null;

            // 
            // Start algorithm
            //

            node = this;
            sons = node.Children;

            // 
            // Find the node where to insert the value
            //

            for (i = 0; i < path.Length && sons.ContainsKey(path[i]); i++)
            {
                node = sons[path[i]];
                sons = node.Children;
            }

            //
            // Insert the number of nodes necessary to finish
            // the intended tree structure, if the node where to
            // insert is not valid we dont insert it
            //

            if (null != node)
            {
                for (j = i; j < path.Length; j++)
                {
                    TreeNodeKey<K, T> folderNode = new TreeNodeKey<K, T>(path[j], folderDelegate(path[j], value));
                    node.Add(folderNode);
                    node = folderNode;
                }
            }

            //
            // Finally insert the value, we test the value of the leaf delegate,
            // because we want the user to be able to set it to null, effectivaly
            // generating a tree who nodes are simply the folders, useful for 
            // generating tree category nodes.
            //

            if ((null != node) && (null != leafDelegate))
            {
                K nextKey = keyGen.GetKey();
                TreeNodeKey<K, T> leafNode = new TreeNodeKey<K, T>(nextKey, leafDelegate(value));
                node.Add(leafNode);
            }
        }

        protected XElement UnparseToXML_DocumentOrder(Func<bool, bool, T, XElement> gene, bool root = true)
        {
            XElement result = gene(root, IsLeaf, Info);

            if (!IsLeaf)
            {
                foreach (var child in OrderedChildren)
                {
                    result.Add(child.UnparseToXML_DocumentOrder(gene, false));
                }
            }

            return result;
        }

        protected XElement UnparseToXML_KeyOrder(Func<bool, bool, T, XElement> gene, bool root = true)
        {
            XElement result = gene(root, IsLeaf, Info);

            if (!IsLeaf)
            {
                foreach (TreeNodeKey<K, T> child in Children.Values)
                {
                    result.Add(child.UnparseToXML_KeyOrder(gene, false));
                }
            }

            return result;
        }

        protected XElement UnparseToXML_FoldersFirst(Func<bool, bool, T, XElement> gene, bool root = true)
        {
            XElement result = gene(root, IsLeaf, Info);

            if (!IsLeaf)
            {
                foreach (TreeNodeKey<K, T> child in Children.Values)
                {
                    if (child.Children.Count > 0)
                    {
                        result.Add(child.UnparseToXML_FoldersFirst(gene, false));
                    }
                }

                foreach (TreeNodeKey<K, T> child in Children.Values)
                {
                    if (child.Children.Count == 0)
                    {
                        result.Add(child.UnparseToXML_FoldersFirst(gene, false));
                    }
                }
            }

            return result;
        }

        protected XElement UnparseToXML_LeafsFirst(Func<bool, bool, T, XElement> gene, bool root = true)
        {
            XElement result = gene(root, IsLeaf, Info);

            if (!IsLeaf)
            {
                foreach (TreeNodeKey<K, T> child in Children.Values)
                {
                    if (child.Children.Count == 0)
                    {
                        result.Add(child.UnparseToXML_LeafsFirst(gene, false));
                    }
                }

                foreach (TreeNodeKey<K, T> child in Children.Values)
                {
                    if (child.Children.Count > 0)
                    {
                        result.Add(child.UnparseToXML_LeafsFirst(gene, false));
                    }
                }
            }

            return result;
        }

        //
        // String representation for tree.
        // Build a textual visual tree for this datatype.
        // Use the ToString method for key and info values.
        //

        public override string ToString()
        {
            return ToStringRec(0);
        }

        //
        // Recursive string value builder.
        // Method to perform the actual ToString operation for node.
        //

        protected string ToStringRec(int level)
        {
            string str = string.Empty;

            //
            // Unparse this node.
            //

            str += Framework.Core.Helpers.StringHelper.Repeat("-", level * 2);
            str += string.Format("[{0}, {1}]", Key, Info);
            str += System.Environment.NewLine;

            // 
            // Unparse this node's children
            // 

            foreach (TreeNodeKey<K, T> child in OrderedChildren)
            {
                str += child.ToStringRec(level + 1);
            }

            // 
            // Return result
            //

            return str;
        }

        // 
        // PRIVATE FIELDS
        //

        private K _Key = default(K);
        private T _Info = default(T);
        private SortedDictionary<K, TreeNodeKey<K, T>> _Children = null;
        private List<TreeNodeKey<K, T>> _OrderedChildren = null;
    }
}
