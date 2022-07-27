using UniRx;

namespace _Scripts.Gameplay.Tile
{
    public interface ISelectable
    {
        IReactiveProperty<bool> IsSelected { get; }
        
        void Select();
        void UnSelect();
    }
}