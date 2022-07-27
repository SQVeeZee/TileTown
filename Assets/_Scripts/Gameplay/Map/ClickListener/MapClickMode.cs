using System;

namespace _Scripts.Gameplay.Tile.Map.Click
{
    [Flags]
    public enum MapClickMode
    {
        None = 0,

        Selection = 1,
        Move = 2,
        
        All = ~0
    }
}