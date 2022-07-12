using System;
using DG.Tweening;
using UI.View.Configs;
using UnityEngine;
using Zenject;

public abstract class BaseUIView : MonoBehaviour, IUIView
{
    [SerializeField] private Canvas m_canvas = null;
    [SerializeField] private CanvasGroup m_canvasGroup = null;

    private UIViewConfigs m_viewConfigs = null;
    private Tweener m_tween = null;
    
    [Inject]
    public void Constructor(
        UIViewConfigs viewConfigs
        )
    {
        m_viewConfigs = viewConfigs;
    }

    private void Start()
    {
        DoHide(true);
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
