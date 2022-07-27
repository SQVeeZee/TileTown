using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace _Scripts.Tools.Container
{
    public class BaseSimpleContainer<T>
    {
        public event Action<T> Added = null; 
        public event Action<T> Removed = null; 
        public event Action Cleared = null; 


        private readonly List<T> _items = null;


        public int Count => _items.Count;
        public T this[int index] => GetAt(index);


        [UsedImplicitly]
        public BaseSimpleContainer()
        {
            _items = new List<T>();
        }

        public BaseSimpleContainer(int capacity)
        {
            _items = new List<T>(capacity);
        }

        public void Add(T item)
        {
            _items.Add(item);
            Added?.Invoke(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
            Removed?.Invoke(item);
        }

        public void Clear()
        {
            _items.Clear();
            Cleared?.Invoke();
        }

        private T GetAt(int index)
        {
            return _items[index];
        }
    }
}
