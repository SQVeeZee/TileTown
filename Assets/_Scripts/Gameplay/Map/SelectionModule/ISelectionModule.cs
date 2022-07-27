using System;

namespace _Scripts.Gameplay.Tile.Map.Selection
{
    public interface ISelectionModule
    {
        event Action<ITileViewModel> TileSelected;
        
        ITileViewModel SelectedTile { get; }
        
        void Select(ITileViewModel tile);
        void UnSelect();
    }
}