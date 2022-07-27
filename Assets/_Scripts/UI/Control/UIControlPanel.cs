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

        [SerializeField] private UIInput _input = null;

        void IInitializable.Initialize()
        {
            _input.PointerDown += OnPointerDown;
            _input.PointerUp += OnPointerUp;
        }

        void IDisposable.Dispose()
        {
            _input.PointerDown -= OnPointerDown;
            _input.PointerUp -= OnPointerUp;
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