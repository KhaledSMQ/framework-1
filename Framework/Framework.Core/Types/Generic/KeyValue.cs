// ============================================================================
// Project: Framework
// Name/Class: KeyValue
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: KeyValue pair. This is a class not a struct like the 
//              KeyValuePair. Unlike Tuple, this has Key/Value fields instead
//              of properties that can be modified.
// ============================================================================

namespace Framework.Core.Types.Generic
{
    public class KeyValue<TKey, TValue>
    {
        //
        // PROPERTIES
        //

        public TKey Key { get; set; }
        public TValue Value { get; set; }

        //
        // CONSTRUCTORS
        //

        public KeyValue() : this(default(TKey), default(TValue)) { }

        public KeyValue(TKey key, TValue val)
        {
            Key = key;
            Value = val;
        }

        //
        // TO-STRING
        // String representation of this object instance.
        //

        public override string ToString()
        {
            return string.Format("{0}:{1}", Key, Value);
        }
    }
}
