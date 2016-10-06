// ============================================================================
// Project: Framework
// Name/Class: Dict2D
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Sorted Table. Table that stores values where its indexes are 
//              generic objects. This class is similar to a normal two 
//              dimensional array, but with indexes implemented as generic
//              object instances. Object indexes should have the capacity of 
//              being converted to an hash value.
// ============================================================================

using Framework.Core.Error;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Core.Collections.Generic
{
    public class Dict2D<K, T> : SortedDictionary<K, SortedDictionary<K, T>>
    {
        //
        // Add a new value to the sorted map
        // We need the X and Y dimensions
        // @param x The X index
        // @param y The y index
        // @param value The value to insert
        //

        public void Add(K x, K y, T value)
        {
            if (!ContainsKey(x))
            {
                Add(x, new SortedDictionary<K, T>());
            }

            if (!this[x].ContainsKey(y))
            {
                this[x].Add(y, value);
            }
        }

        //
        // Get the value located at a specific x and y indexes
        // @param x The X index
        // @param y The Y index
        // @return The value located at the specified X and Y index
        //

        public T GetY(K x, K y)
        {
            T value = default(T);

            if (ContainsKey(x))
            {
                if (this[x].ContainsKey(y))
                {
                    value = this[x][y];
                }
                else
                {
                    Throw.WithPrefix(Config.Lib.DEFAULT_ERROR_MSG_PREFIX, "'{0}' y index does not exist in table", y);
                }
            }
            else
            {
                Throw.WithPrefix(Config.Lib.DEFAULT_ERROR_MSG_PREFIX, "'{0}' x index does not exist in table", x);
            }

            return value;
        }

        //
        // Get a list of value in a certain X index
        // @param x The X index
        // @eturn The list of values n that X index
        // 

        public IEnumerable<T> GetY(K x)
        {
            IEnumerable<T> values = default(IEnumerable<T>);

            if (ContainsKey(x))
            {
                values = this[x].Values.ToList();
            }
            else
            {
                Throw.WithPrefix(Config.Lib.DEFAULT_ERROR_MSG_PREFIX, "'{0}' x index does not exist in table", x);
            }

            return values;
        }
    }
}
