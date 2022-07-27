using System;
using _Scripts.Gameplay.Tile;
using JetBrains.Annotations;

namespace _Scripts.Gameplay.Building.Impacts.Move
{
    [UsedImplicitly]
    public class MoveImpactModule: IMoveImpactModule
    {
        public event Action MoveImpactCompleted;
        
        private ITileViewModel _selectedTile = null;

        void IMoveImpactModule.DoMoveImpact(ITileViewModel clickedTile, ITileViewModel targetTile)
        {
            if (!targetTile.IsEmpty) return;
            
            _selectedTile = clickedTile;
            var building = clickedTile.Building;

            targetTile.Building = building;
            building.MoveBuilding(targetTile.BuildingContainer);

            _selectedTile.Building = null;
            _selectedTile.UnSelect();
            
            MoveImpactCompleted?.Invoke();
        }
    }
}