using System;
using _Scripts.Gameplay.Building.Impact.Impacts;
using _Scripts.Gameplay.Tile;
using _Scripts.Gameplay.Tile.Map;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building.Impact.Move
{
    public class MoveImpactViewModel: BaseImpactViewModel
    {
        public event Action ImpactActivated = null;
        public event Action ImpactCompleted = null;
        
        private readonly MoveImpactModel m_model = null;
        private readonly MapController m_mapController = null;

        protected override EImpactType m_impactType => m_model.ImpactType;

        [Inject]
        public MoveImpactViewModel(
            ImpactsController impactsController,
            MoveImpactModel model,
            MapController mapController
        ) : base(impactsController)
        {
            m_model = model;

            m_mapController = mapController;
        }

        protected override void Dispose() { }
        protected override void Initialize() { }

        
        protected override void DoImpact()
        {
            m_mapController.DisableBuilder();
            m_mapController.DisableImpactsMenu();
            
            m_mapController.UpdateSelectedTile += OnUpdateSelectedTile;
            
            ImpactActivated?.Invoke();
        }

        private void OnUpdateSelectedTile(TileController previousTile, TileController selectedTile)
        {
            ReplaceSelectedBuildingPosition(selectedTile, previousTile.BuildingViewModel);
        }
        
        private void ReplaceSelectedBuildingPosition(TileController tileController, BuildingViewModel selectedBuilding)
        {
            if (tileController.TileState != ETileState.EMPTY) return;

            Transform targetTransform = tileController.TileTransform;
            selectedBuilding.ChangePosition(targetTransform);

            tileController.SetTileBuilding(selectedBuilding);
            
            m_mapController.UpdateSelectedTile -= OnUpdateSelectedTile;

            m_mapController.ResetInteractionState();
            
            ImpactCompleted?.Invoke();
        }
    }
}