using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public interface ILinkedList<T> : IEnumerable<T>
    {
        ListNode<T> Head { get; }

        void Insert(T data);

        void InsertSorted(T data);

        void InsertRange(IEnumerable<T> range);

        void InsertRangeSorted(IEnumerable<T> range);
    }

    public class LinkedList<T> : ILinkedList<T>
    {
        public ListNode<T> Head { get; private set; }        

        public LinkedList(IEnumerable<T> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));

            InsertRangeSorted(values);
        }

        public void Insert(T data)
        {
            if (Head == null)
            {
                Head = new ListNode<T>(data);
            }
            else
            {
                var current = Head;
                var newNode = new ListNode<T>(data);
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }
        }

        public void InsertSorted(T data)
        {
            var newNode = new ListNode<T>(data);
            if (Head == null || Comparer<T>.Default.Compare(Head.Value, data) > 0)
            {
                newNode.Next = Head;
                Head = newNode;
            }
            else
            {
                var current = Head;
                while (current.Next != null && 
                       Comparer<T>.Default.Compare(current.Next.Value, data) < 0)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }

        public void InsertRange(IEnumerable<T> range)
        {
            if (range.IsNullOrEmpty()) return;

            var sorted = range.ToList();            

            foreach (var item in sorted)
            {
                Insert(item);
            }
        }

        public void InsertRangeSorted(IEnumerable<T> range)
        {
            if (range.IsNullOrEmpty()) return;

            var sorted = range.ToList();

            foreach (var item in sorted)
            {
                InsertSorted(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            return this.Select(_ => sb.Append(_).Append("->")).ToString();
        }
    }
}