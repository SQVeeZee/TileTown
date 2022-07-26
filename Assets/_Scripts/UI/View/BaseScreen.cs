using System;
using _Scripts.UI.Screen.Configs;
using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Screen
{
    public abstract class BaseScreen : MonoBehaviour, IScreen
    {
        [SerializeField] protected RectTransform m_transform = null;
        [SerializeField] private UnityEngine.Canvas m_canvas = null;
        [SerializeField] private CanvasGroup m_canvasGroup = null;

        public BoolReactiveProperty IsReadyToHide { get; } = new BoolReactiveProperty();

        public abstract void Initialize();
        public abstract void Dispose();

        private UIViewConfigs m_viewConfigs = null;
        private Tweener m_tween = null;
        
        protected virtual void OnBeforeScreenShow() { }

        protected virtual void OnAfterScreenShow() { }

        protected virtual void OnBeforeScreenHide()
        {
            IsReadyToHide.Value = false;
        }
        protected virtual void OnAfterScreenHide() { }
        
        [Inject]
        public void Constructor(
            UIViewConfigs viewConfigs
        )
        {
            m_viewConfigs = viewConfigs;
        }

        protected virtual void Awake()
        {
            DoHide(true);
        }

        public void DoShow(bool force = false, Action callback = null)
        {
            OnBeforeScreenShow();
            
            ResetTween();

            m_canvasGroup.alpha = 0;
            m_canvas.enabled = true;

            m_tween = m_canvasGroup.DOFade(1, m_viewConfigs.ShowDuration)
                .OnComplete(OnShow);

            void OnShow()
            {
                callback?.Invoke();
                
                OnAfterScreenShow();
            }
        }

        public void DoHide(bool force = false, float delay = 0f, Action callback = null)
        {
            OnBeforeScreenHide();
            
            ResetTween();

            m_canvas.enabled = false;

            m_tween = m_canvasGroup.DOFade(1, m_viewConfigs.ShowDuration).SetDelay(delay)
                .OnComplete(OnHide);

            void OnHide()
            {
                callback?.Invoke();
                
                OnAfterScreenHide();
            }
        }

        protected void HideThisScreen()
        {
            IsReadyToHide.Value = true;
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