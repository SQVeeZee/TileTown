using System;

namespace _Scripts.Gameplay.Tile.Map.Click
{
    public interface IClickModeListener
    {
        public event Action<MapClickMode> ClickModeChanged;
        public event Action<MapClickMode> ClickModeAdded;
        public event Action<MapClickMode> ClickModeRemoved;

        void AddClickMode(MapClickMode clickMode);
        void RemoveClickMode(MapClickMode clickMode);

        bool HasClickMode(MapClickMode clickMode);
    }
}