using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode.Collections.Set
{
    public class OrderedSet<T> : IOrderedSet<T> where T : IEquatable<T>
    {
        private readonly HashSet<T> _lookup = new HashSet<T>();
        private readonly LinkedList<T> _elements = new LinkedList<T>();

        public long Count => _lookup.Count;

        public OrderedSet(IEnumerable<T> collection = null)
        {
            if (collection != null)
            {
                AddRange(collection);
            }
        }

        public void Add(T item)
        {
            if (_lookup.Contains(item)) return;

            _elements.AddLast(item);
            _lookup.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach(var item in items)
            {
                Add(item);
            }
        }

        public bool Remove(T item)
        {            
            if (_lookup.Contains(item))
            {
                _lookup.Remove(item);
                _elements.Remove(item);

                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
