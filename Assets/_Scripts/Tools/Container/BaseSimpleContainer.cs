using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Tools
{
    public class BaseSimpleContainer<T>
    {
        public event Action<T> Added = null; 
        public event Action<T> Removed = null; 
        public event Action Cleared = null; 


        private readonly List<T> m_items = null;


        public int Count => m_items.Count;
        public T this[int index] => GetAt(index);


        [UsedImplicitly]
        public BaseSimpleContainer()
        {
            m_items = new List<T>();
        }

        public BaseSimpleContainer(int capacity)
        {
            m_items = new List<T>(capacity);
        }

        public void Add(T item)
        {
            m_items.Add(item);
            Added?.Invoke(item);
        }

        public void Remove(T item)
        {
            m_items.Remove(item);
            Removed?.Invoke(item);
        }

        public void Clear()
        {
            m_items.Clear();
            Cleared?.Invoke();
        }

        private T GetAt(int index)
        {
            return m_items[index];
        }
    }
}
