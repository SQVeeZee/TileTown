using System;

public interface IUIView
{
    void DoShow(bool force = false, Action callback = null);
    void DoHide(bool force = false, Action callback = null);
}
