using System;
using _Scripts.UI.View.Configs;
using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Screen
{
    public abstract class BaseScreen : MonoBehaviour, IScreen
    {
        [SerializeField] protected RectTransform _transform = null;
        [SerializeField] private UnityEngine.Canvas _canvas = null;
        [SerializeField] private CanvasGroup _canvasGroup = null;

        public BoolReactiveProperty IsReadyToHide { get; } = new BoolReactiveProperty();

        public abstract void Initialize();
        public abstract void Dispose();

        private UIViewConfigs _viewConfigs = null;
        private Tweener _tween = null;
        
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
            _viewConfigs = viewConfigs;
        }

        protected virtual void Awake()
        {
            DoHide(true);
        }

        public void DoShow(bool force = false, Action callback = null)
        {
            OnBeforeScreenShow();
            
            ResetTween();

            _canvasGroup.alpha = 0;
            _canvas.enabled = true;

            _tween = _canvasGroup.DOFade(1, _viewConfigs.ShowDuration)
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

            _canvas.enabled = false;

            _tween = _canvasGroup.DOFade(1, _viewConfigs.HideDuration).SetDelay(delay)
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
            if (_tween == null) return;

            _tween.Kill();
            _tween = null;
        }

        private void OnDestroy()
        {
            ResetTween();
        }
    }
}