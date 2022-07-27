using _Scripts.Gameplay.Tile;

namespace _Scripts.Gameplay.Building.Impacts
{
    public interface IImpact
    {
        void DoImpact(ITileViewModel tileViewModel);
        void ResetImpact();
    }
}