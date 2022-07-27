using System;
using _Scripts.Gameplay.Tile;

namespace _Scripts.Gameplay.Building.Impacts.Move
{
    public interface IMoveImpactModule
    {
        event Action MoveImpactCompleted;
        void DoMoveImpact(ITileViewModel clickedTile, ITileViewModel targetTile);
    }
}