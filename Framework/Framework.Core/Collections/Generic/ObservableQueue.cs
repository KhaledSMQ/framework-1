// ============================================================================
// Project: Framework
// Name/Class: ObservableQueue
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Observable queue implementation.
// ============================================================================

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Framework.Core.Collections.Generic
{
    public class ObservableQueue<T> : INotifyCollectionChanged, IEnumerable<T>
    {
        //
        // PROPERTIES
        //

        public int Count { get { return _Queue.Count; } }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        //
        // QUEUE MANIPULATION
        // Insert and remove items from queue.
        //

        public void Enqueue(T item)
        {
            _Queue.Enqueue(item);

            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            }
        }

        public T Dequeue()
        {
            var item = _Queue.Dequeue();

            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
            }

            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _Queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //
        // PRIVATE FIELDS
        // 

        private readonly Queue<T> _Queue = new Queue<T>();
    }
}