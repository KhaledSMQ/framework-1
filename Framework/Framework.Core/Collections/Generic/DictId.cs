// ============================================================================
// Project: Framework
// Name/Class: DictId
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 15/Jul/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Error;
using Framework.Core.Patterns;
using Framework.Core.Extensions;
using Framework.Core.Types.Specialized;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Core.Collections.Generic
{
    public class DictId<T> : SortedDictionary<Id, T>
    {
        public new void Add(Id key, T value)
        {
            if (!ContainsKey(key))
            {
                Add(key, value);
            }
            else
            {
                Throw.Fatal(Config.Lib.DEFAULT_ERROR_MSG_PREFIX, ERR_DUPLICATE_MESSAGE, key);
            }
        }

        public T Get(Id key)
        {
            T val = this[key];

            if (val.IsNull())
            {
                Throw.Fatal(Config.Lib.DEFAULT_ERROR_MSG_PREFIX, ERR_UNDEFINED_MESSAGE, key);
            }

            return val;
        }

        public bool Exists(Id key)
        {
            return ContainsKey(key);
        }

        public bool NotExists(Id key)
        {
            return !Exists(key);
        }

        public IEnumerable<T> GetList()
        {
            return Values.ToList();
        }

        public void Delete(Id key)
        {
            if (ContainsKey(key))
            {
                Remove(key);
            }
        }

        //
        // MESSAGES
        //

        protected string ERR_INVALID_MESSAGE = "invalid value '{0}'";
        protected string ERR_DUPLICATE_MESSAGE = "value '{0}' was already defined!";
        protected string ERR_UNDEFINED_MESSAGE = "value '{0}' was not foud!";
    }

    public class DictIdWithIDValue<T> : DictId<T> where T : IID<Id>, new()
    {
        public void Add(IEnumerable<T> values)
        {
            values.Apply(Add);
        }

        public void Add(T value)
        {
            if (value.IsNotNull() && value.ID.IsNotNull())
            {
                if (NotExists(value.ID))
                {
                    Add(value.ID, value);
                }
                else
                {
                    //
                    // ERROR: value key already exists.
                    //

                    Throw.Fatal(Config.Lib.DEFAULT_ERROR_MSG_PREFIX, ERR_DUPLICATE_MESSAGE, value.ID);
                }
            }
            else
            {
                //
                // ERROR: value or value key is invalid.
                //

                Throw.Fatal(Config.Lib.DEFAULT_ERROR_MSG_PREFIX, ERR_INVALID_MESSAGE, value.ID);
            }
        }
    }
}
