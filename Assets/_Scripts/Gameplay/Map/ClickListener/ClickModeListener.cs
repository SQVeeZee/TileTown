using System;
using JetBrains.Annotations;

namespace _Scripts.Gameplay.Tile.Map.Click
{
    [UsedImplicitly]
    public class ClickModeListener: IClickModeListener
    {
        public event Action<MapClickMode> ClickModeChanged;
        public event Action<MapClickMode> ClickModeAdded;
        public event Action<MapClickMode> ClickModeRemoved;

        private MapClickMode _clickMode = MapClickMode.Selection;

        void IClickModeListener.AddClickMode(MapClickMode clickMode)
        {
            if (clickMode == MapClickMode.Move)
            {
                ChangeClickMode(clickMode);
            }
            else
            {
                AddClickMode(clickMode);
            }
        }
        
        void IClickModeListener.RemoveClickMode(MapClickMode clickMode)
        {
            RemoveClickMode(clickMode);
        }

        bool IClickModeListener.HasClickMode(MapClickMode clickMode) => _clickMode.HasFlag(clickMode);

        private void AddClickMode(MapClickMode clickMode)
        {
            _clickMode |= clickMode;

            ClickModeAdded?.Invoke(clickMode);
        }

        private void RemoveClickMode(MapClickMode clickMode)
        {
            _clickMode &= ~clickMode;

            if (_clickMode.HasFlag(MapClickMode.None))
            {
                SetDefaultClickMode();
            }
            
            ClickModeRemoved?.Invoke(clickMode);
        }

        private void SetDefaultClickMode()
        {
            ChangeClickMode(MapClickMode.Selection);
        }

        private void ChangeClickMode(MapClickMode clickMode)
        {
            _clickMode = clickMode;
            
            ClickModeChanged?.Invoke(_clickMode);
        }
    }
}