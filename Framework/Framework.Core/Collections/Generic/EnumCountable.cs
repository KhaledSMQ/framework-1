// ============================================================================
// Project: Framework
// Name/Class: CountableEnumerator
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Implementation for the Countable enumerator pattern.
// ============================================================================

using System.Collections.Generic;
using Framework.Core.Patterns;

namespace Framework.Core.Collections.Generic
{
    public class EnumCountable<T> : IEnumCountable<T>
    {
        //
        // CONSTRCUTORS
        //

        public EnumCountable(IList<T> list)
        {
            _List = list;
            _CurrentIndex = -1;
        }

        //
        // IEnumerator<T>
        //

        public T Current
        {
            get
            {
                if (_CurrentIndex > -1 && _CurrentIndex < _List.Count)
                {
                    return _List[_CurrentIndex];
                }

                return default(T);
            }
        }

        //
        // IEnumerator
        //

        object System.Collections.IEnumerator.Current
        {
            get { return _List[_CurrentIndex]; }
        }

        public bool MoveNext()
        {
            if (_CurrentIndex < _List.Count - 1)
            {
                _CurrentIndex++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _CurrentIndex = -1;
        }

        //
        // ICountableEnumerator<T>
        //

        public bool IsFirst()
        {
            return _CurrentIndex == 0;
        }

        public bool IsLast()
        {
            return _CurrentIndex == _List.Count - 1;
        }

        public int CurrentIndex
        {
            get { return _CurrentIndex; }
        }

        public int Count
        {
            get { return _List.Count; }
        }

        public bool IsEmpty
        {
            get { return (_List == null || _List.Count == 0); }
        }

        //
        // IDisposable
        //

        public void Dispose() { }

        //
        // PRIVATE PROPERTIES
        //

        private IList<T> _List;
        private int _CurrentIndex;
    }
}
