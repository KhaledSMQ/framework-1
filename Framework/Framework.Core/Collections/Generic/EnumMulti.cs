// ============================================================================
// Project: Framework
// Name/Class: EnumMulti
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using System.Collections.Generic;

namespace Framework.Core.Collections.Generic
{
    public class EnumMulti<T> : IEnumerator<T>
    {
        //
        // CONSTRUCTORS
        //

        public EnumMulti(IList<IEnumerator<T>> allEnumerators)
        {
            _AllEnumerators = allEnumerators;
            _CurrEnumeratorIndex = -1;
        }

        //
        // IEnumerator<T>
        //

        //
        // Get the current item.
        //

        public T Current
        {
            get
            {
                if (_IsWithinBounds())
                {
                    return _AllEnumerators[_CurrEnumeratorIndex].Current;
                }

                return default(T);
            }
        }

        //
        // IEnumerator
        //

        //
        // Get the current item in list.
        //       

        object System.Collections.IEnumerator.Current
        {
            get
            {
                if (_IsWithinBounds())
                {
                    return _AllEnumerators[_CurrEnumeratorIndex].Current;
                }

                return null;
            }
        }

        //
        // Move to the next item.
        //

        public bool MoveNext()
        {
            // 
            // Check for case where moving to first one.
            //

            if (_CurrEnumeratorIndex == -1)
            {
                _MoveToNextEnumerator();
            }

            // 
            // Can move on the current enumerator?
            //

            if (_CurrEnumerator.MoveNext())
            {
                return true;
            }

            // 
            // Last enumerator - can not move anymore.
            //

            if (_CurrEnumeratorIndex == _AllEnumerators.Count - 1)
            {
                return false;
            }

            // 
            // Ok. move to the next enumerator.
            //

            _MoveToNextEnumerator();

            //
            // If past
            // Now move next on the next enumerator.
            //

            return _CurrEnumerator.MoveNext();
        }

        //
        // Reset the iterator to first item enumerator.
        //

        public void Reset()
        {
            _CurrEnumeratorIndex = -1;
            _CurrEnumerator = null;
        }

        //
        // IDisposable
        //

        public void Dispose() { }

        //
        // HELPERS
        //

        private void _MoveToNextEnumerator()
        {
            _CurrEnumeratorIndex++;
            _CurrEnumerator = _AllEnumerators[_CurrEnumeratorIndex];
        }

        //
        // Check if current index referencing the enumerator in the list 
        // is within bounds.
        //

        private bool _IsWithinBounds()
        {
            return _CurrEnumeratorIndex > -1 && _CurrEnumeratorIndex < _AllEnumerators.Count;
        }

        //
        // PRIVATE FIELDS
        //

        private IEnumerator<T> _CurrEnumerator;
        private IList<IEnumerator<T>> _AllEnumerators;
        private int _CurrEnumeratorIndex;
    }
}
