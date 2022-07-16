using System;
using _Scripts.UI.Canvas;
using DG.Tweening;
using _Scripts.UI.View.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.View
{
    public abstract class BaseUIView : MonoBehaviour, IUIView
    {
        [SerializeField] protected RectTransform m_transform = null;
        [SerializeField] private UnityEngine.Canvas m_canvas = null;
        [SerializeField] private CanvasGroup m_canvasGroup = null;

        private UIViewConfigs m_viewConfigs = null;
        private Tweener m_tween = null;

        private UICanvas m_uiCanvas = null;

        [Inject]
        public void Constructor(
            UIViewConfigs viewConfigs,
            UICanvas uiCanvas
        )
        {
            m_viewConfigs = viewConfigs;
            m_uiCanvas = uiCanvas;
        }

        private void Start()
        {
            SetupTransform();

            DoHide(true);
        }

        private void SetupTransform()
        {
            if (m_transform == null)
                m_transform = GetComponent<RectTransform>();

            m_transform.SetParent(m_uiCanvas.ViewParent, false);
        }

        public void DoShow(bool force = false, Action callback = null)
        {
            ResetTween();

            m_canvasGroup.alpha = 0;
            m_canvas.enabled = true;

            m_tween = m_canvasGroup.DOFade(1, m_viewConfigs.ShowDuration)
                .OnComplete(OnShow);

            void OnShow()
            {
                callback?.Invoke();
            }
        }

        public void DoHide(bool force = false, Action callback = null)
        {
            ResetTween();

            m_canvas.enabled = false;

            m_tween = m_canvasGroup.DOFade(1, m_viewConfigs.ShowDuration)
                .OnComplete(OnHide);

            void OnHide()
            {
                callback?.Invoke();
            }
        }

        private void ResetTween()
        {
            if (m_tween == null) return;

            m_tween.Kill();
            m_tween = null;
        }

        private void OnDestroy()
        {
            ResetTween();
        }
    }
}