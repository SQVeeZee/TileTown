using System;
using UnityEngine;
using Zenject;

namespace Gameplay.UI.Control
{
    public class ControlController : IInitializable, IDisposable
    {
        public event Action<Vector2> Clicked = null;
        
        private readonly UIControlPanel m_controlPanel = null;

        private float m_clickRange = 0.5f;

        private float m_leftLimit = 0;
        private float m_rightLimit = 10;

        private Vector2 m_pointerPosition = default;
        
        [Inject]
        public ControlController(
            UIControlPanel controlPanel
        )
        {
            m_controlPanel = controlPanel;
        }

        void IInitializable.Initialize()
        {
            m_controlPanel.PointerDown += OnPointerDown;
            m_controlPanel.PointerUp += OnPointerUp;
        }

        void IDisposable.Dispose()
        {
            m_controlPanel.PointerDown -= OnPointerDown;
            m_controlPanel.PointerUp -= OnPointerUp;
        }

        private void OnPointerDown(Vector2 viewPoint)
        {
            m_pointerPosition = viewPoint;
        }

        private void OnPointerUp(Vector2 viewPoint)
        {
            if (Vector2.Distance(m_pointerPosition, viewPoint) < m_clickRange)
            {
                Clicked?.Invoke(viewPoint);
            }
        }
    }
}