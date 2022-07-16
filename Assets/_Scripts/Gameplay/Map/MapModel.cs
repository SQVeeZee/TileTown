using System;
using JetBrains.Annotations;

namespace _Scripts.Gameplay.Tile.Map
{
    [Flags]
    public enum EMapInteractionState
    {
        NONE = 0,
        
        CLICKS = 1,
        BUILDER = 2,
        IMPACTS = 4,
        
        ALL = ~0
    }
    
    [UsedImplicitly]
    public class MapModel
    {
    }
}