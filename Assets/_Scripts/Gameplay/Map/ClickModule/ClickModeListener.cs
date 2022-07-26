using System;
using JetBrains.Annotations;

namespace _Scripts.Gameplay.Tile.Map.Click
{
    [Flags]
    public enum MapClickMode
    {
        NONE = 0,

        SELECTION = 1,
        MOVE = 2,
        
        ALL = ~0
    }
    
    public interface IClickModeListener
    {
        public event Action<MapClickMode> ClickModeChanged;
        public event Action<MapClickMode> ClickModeAdded;
        public event Action<MapClickMode> ClickModeRemoved;

        void AddClickMode(MapClickMode clickMode);
        void RemoveClickMode(MapClickMode clickMode);

        bool HasClickMode(MapClickMode clickMode);
    }
    
    [UsedImplicitly]
    public class ClickModeListener: IClickModeListener
    {
        public event Action<MapClickMode> ClickModeChanged;
        public event Action<MapClickMode> ClickModeAdded;
        public event Action<MapClickMode> ClickModeRemoved;

        private MapClickMode m_clickMode = MapClickMode.SELECTION;

        void IClickModeListener.AddClickMode(MapClickMode clickMode)
        {
            if (clickMode == MapClickMode.MOVE)
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

        bool IClickModeListener.HasClickMode(MapClickMode clickMode) => m_clickMode.HasFlag(clickMode);

        private void AddClickMode(MapClickMode clickMode)
        {
            m_clickMode |= clickMode;

            ClickModeAdded?.Invoke(clickMode);
        }

        private void RemoveClickMode(MapClickMode clickMode)
        {
            m_clickMode &= ~clickMode;

            if (m_clickMode.HasFlag(MapClickMode.NONE))
            {
                SetDefaultClickMode();
            }
            
            ClickModeRemoved?.Invoke(clickMode);
        }

        private void SetDefaultClickMode()
        {
            ChangeClickMode(MapClickMode.SELECTION);
        }

        private void ChangeClickMode(MapClickMode clickMode)
        {
            m_clickMode = clickMode;
            
            ClickModeChanged?.Invoke(m_clickMode);
        }
    }
}