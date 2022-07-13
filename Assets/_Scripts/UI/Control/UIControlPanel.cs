using System;
using _Scripts.UI.Input;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Control
{
    public class UIControlPanel : MonoBehaviour, IInitializable, IDisposable
    {
        public event Action<Vector2> PointerDown = null;
        public event Action<Vector2> PointerUp = null;

        [SerializeField] private UIInput m_uiInput = null;

        void IInitializable.Initialize()
        {
            m_uiInput.PointerDown += OnPointerDown;
            m_uiInput.PointerUp += OnPointerUp;
        }

        void IDisposable.Dispose()
        {
            m_uiInput.PointerDown -= OnPointerDown;
            m_uiInput.PointerUp -= OnPointerUp;
        }

        private void OnPointerDown(Vector2 position)
        {
            PointerDown?.Invoke(position);
        }
        
        private void OnPointerUp(Vector2 position)
        {
            PointerUp?.Invoke(position);
        }
    }
}