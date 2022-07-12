using System;
using System.Collections.Generic;
using JetBrains.Annotations;

public class BaseSimpleModel<T>
{
    public event Action<T> Added = null;
    public event Action<T> Removed = null;
    public event Action Cleared = null;

    public int Count => m_items.Count;
    public T this[int index] => GetAt(index);
    
    private readonly List<T> m_items = null;

    [UsedImplicitly]
    public BaseSimpleModel()
    {
        m_items = new List<T>();
    }

    public BaseSimpleModel(int capacity)
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