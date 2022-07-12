using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action<Vector2> PointerDown = null;
    public event Action<Vector2> PointerUp = null;
    
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        PointerDown?.Invoke(eventData.position);
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        PointerUp?.Invoke(eventData.position);
    }
}
