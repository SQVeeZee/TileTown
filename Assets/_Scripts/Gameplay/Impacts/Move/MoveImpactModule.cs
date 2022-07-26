using System;
using _Scripts.Gameplay.Tile;
using _Scripts.Gameplay.Tile.Map.Selection;
using Zenject;

namespace _Scripts.Gameplay.Building.Impacts.Move
{
    public interface IMoveImpactModule
    {
        void DoMoveImpact(ITileViewModel targetTile, Action callback);
        void ResetTileSelection();
    }

    public class MoveImpactModule: IMoveImpactModule
    {
        private readonly ISelectionModule m_selectionModule = null;

        private ITileViewModel m_selectedTile = null;
        
        [Inject]
        public MoveImpactModule(
            ISelectionModule selectionModule
        )
        {
            m_selectionModule = selectionModule;
        }
        
        void IMoveImpactModule.DoMoveImpact(ITileViewModel targetTile, Action callback)
        {
            if (!targetTile.IsEmpty) return;
            
            m_selectedTile = m_selectionModule.SelectedTile;
            var building = m_selectedTile.Building;

            targetTile.Building = building;
            building.MoveBuilding(targetTile.BuildingContainer);
            
            callback?.Invoke();
        }

        void IMoveImpactModule.ResetTileSelection()
        {
            m_selectedTile.Building = null;
            m_selectionModule.UnSelect();
        }
    }
}