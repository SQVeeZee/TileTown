using System;
using UniRx;

namespace _Scripts.UI.Screen
{
    public interface IScreen
    {
        BoolReactiveProperty IsReadyToHide { get; }
        
        void Initialize();
        void Dispose();
        void DoShow(bool force = false, Action callback = null);
        void DoHide(bool force = false, float delay = 0f, Action callback = null);
    }
}