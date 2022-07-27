using System;

namespace _Scripts.Gameplay.Tile.Map.Click
{
    public interface IMapClickHandler
    {
        public event Action<ITileViewModel> TileClicked;
    }
}