using System;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Control
{
    public class ControlController : IInitializable, IDisposable
    {
        public event Action<Vector2> Clicked = null;
        
        private readonly UIControlPanel _controlPanel = null;

        private float _clickRange = 0.5f;

        private Vector2 _pointerPosition = default;
        
        [Inject]
        public ControlController(
            UIControlPanel controlPanel
        )
        {
            _controlPanel = controlPanel;
        }

        void IInitializable.Initialize()
        {
            _controlPanel.PointerDown += OnPointerDown;
            _controlPanel.PointerUp += OnPointerUp;
        }

        void IDisposable.Dispose()
        {
            _controlPanel.PointerDown -= OnPointerDown;
            _controlPanel.PointerUp -= OnPointerUp;
        }

        private void OnPointerDown(Vector2 viewPoint)
        {
            _pointerPosition = viewPoint;
        }

        private void OnPointerUp(Vector2 viewPoint)
        {
            if (Vector2.Distance(_pointerPosition, viewPoint) < _clickRange)
            {
                Clicked?.Invoke(viewPoint);
            }
        }
    }
}