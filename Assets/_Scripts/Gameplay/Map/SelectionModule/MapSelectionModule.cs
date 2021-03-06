using System;
using JetBrains.Annotations;

namespace _Scripts.Gameplay.Tile.Map.Selection
{
    [UsedImplicitly]
    public class MapSelectionModule: ISelectionModule
    {
        public event Action<ITileViewModel> TileSelected;
        public ITileViewModel SelectedTile { get; private set; }
        public void Select(ITileViewModel tile)
        {
            SelectTile(tile);
        }

        public void UnSelect()
        {
            UnselectTile();
        }

        private void SelectTile(ITileViewModel tile)
        {
            UnselectTile();

            SelectedTile = tile;

            SelectedTile.Select();
            
            TileSelected?.Invoke(SelectedTile);
        }

        private void UnselectTile()
        {
            if (SelectedTile == null) return;

            SelectedTile.UnSelect();
            SelectedTile = null;
        }
    }
}