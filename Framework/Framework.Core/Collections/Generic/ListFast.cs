// ============================================================================
// Project: Framework
// Name/Class: ListFast
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Fast list implementation based on an internal array that 
//              grows and shrinks to fit the number of items.
// ============================================================================

using System;
using System.Collections;
using System.Collections.Generic;

namespace Framework.Core.Collections.Generic
{
    public sealed class ListFast<T> : IEnumerable<T>
    {
        //
        // CONSTANTS 
        //

        private const int DEFAULT_SIZE = 4;

        //
        // PROPERTIES
        //

        public int Count
        {
            get { return _Size; }
        }

        public T this[int index]
        {
            get { return _Array[index]; }
            set { _Array[index] = value; }
        }

        //
        // CONSTRUCTORS
        //

        public ListFast() : this(DEFAULT_SIZE) { }

        internal ListFast(int size)
        {
            this._InitialSize = size;
            _Array = new T[size];
        }

        internal ListFast(ListFast<T> list)
        {
            this._InitialSize = list._InitialSize;
            _Array = (T[])list._Array.Clone();
            _Size = list._Size;
        }

        //
        // PUBLIC INTERFACE
        //

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < _Size; i++)
            {
                yield return _Array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T val)
        {
            if (_Size == _Array.Length)
            {
                var dest = new T[_Array.Length == 0 ? DEFAULT_SIZE : _Array.Length * 2];
                Array.Copy(_Array, 0, dest, 0, _Size);
                _Array = dest;
            }

            _Array[_Size++] = val;
        }

        public int IndexOf(T val)
        {
            return Array.IndexOf(_Array, val);
        }

        public bool Remove(T val)
        {
            var index = Array.IndexOf(_Array, val);

            if (index >= 0)
            {
                _Size--;

                if (index < _Size)
                {
                    Array.Copy(_Array, index + 1, _Array, index, _Size - index);
                }

                _Array[_Size] = default(T);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Contains(T val)
        {
            for (var i = 0; i < _Size; i++)
            {
                if (_Array[i].Equals(val))
                {
                    return true;
                }
            }

            return false;
        }

        public T[] ToArray()
        {
            var arr = new T[_Size];
            Array.Copy(_Array, arr, _Size);
            return arr;
        }

        public void Clear()
        {
            _Size = 0;
            _Array = new T[_InitialSize];
        }

        public ListFast<T> Clone()
        {
            var list = new ListFast<T>();
            list._Array = (T[])_Array.Clone();
            list._Size = _Size;
            list._InitialSize = _InitialSize;
            return list;
        }

        //
        // HELPERS
        //

        void Normalize()
        {
            _Size = _Array.Length;
        }

        internal T[] GetRawArray()
        {
            return _Array;
        }

        internal void AddRange(IEnumerable<T> seq)
        {
            foreach (var s in seq)
                Add(s);
        }

        internal void AddRange(ListFast<T> arr, int start, int end)
        {
            for (var i = start; i < end; i++)
                Add(arr[i]);
        }

        internal void AddRange(T[] arr, int start, int end)
        {
            for (var i = start; i < end; i++)
                Add(arr[i]);
        }

        internal void Trim()
        {
            if (_Array.Length > _Size)
            {
                var newArr = new T[_Size];
                Array.Copy(_Array, newArr, _Size);
                _Array = newArr;
            }
        }

        //
        // PRIVATE/INTERNAL FIELDS
        //

        internal static readonly ListFast<T> _Empty = new ListFast<T>();
        private T[] _Array;
        private int _Size;
        private int _InitialSize;
    }
}
