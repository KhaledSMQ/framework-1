// ============================================================================
// Project: Framework
// Name/Class: ITreeNode
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Generic tree node interface collection.
// ============================================================================

using System;
using System.Collections.Generic;

namespace Framework.Core.Patterns
{
    public interface ITreeNode<T>
    {
        //
        // PROPERTIES
        //

        IList<ITreeNode<T>> Children { get; set; }

        T Info { get; set; }

        bool IsLeaf { get; }

        //
        // MAP FUNCTION
        //

        ITreeNode<O> Map<O>(Func<T, object, O> mapDelegate, object accum = null);

        //
        // CATAMORPHISM
        //

        O Cata<O>(Func<T, object, O> emptyDelegate, Func<T, System.Collections.Generic.IList<O>, object, O> consDelegate, object accum = null);

        //
        // UNPARSERS
        //

        string ToVisualTree();
    }
}
