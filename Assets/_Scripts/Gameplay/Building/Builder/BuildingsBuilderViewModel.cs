using System;
using Gameplay.Map;
using Gameplay.Tile;
using UI.Building.Impact.Builder;
using UnityEngine;
using Zenject;

namespace Gameplay.Building.Builder
{
    public class BuildingsBuilderViewModel: IInitializable, IDisposable
    {
        private readonly BuildingBuilderModel m_model = null;
        private readonly UIBuildingsBuilderPanel m_view = null;
        
        private readonly BuildingViewModel.Factory m_buildingsFactory = null;
        private readonly UIBuildingViewModel.Factory m_uiBuildingsFactory = null;

        private TileController m_clickedTile = null;
        
        [Inject]
        public BuildingsBuilderViewModel(
            BuildingBuilderModel model,
            UIBuildingsBuilderPanel view,
            
            BuildingViewModel.Factory buildingsFactory,
            UIBuildingViewModel.Factory uiBuildingsFactory
        )
        {
            m_model = model;
            m_view = view;

            m_buildingsFactory = buildingsFactory;

            m_uiBuildingsFactory = uiBuildingsFactory;
        }

        void IInitializable.Initialize()
        {
            m_model.Added += OnAddedController;
            m_model.Removed += OnAddedController;

            FillGrid();
        }

        void IDisposable.Dispose()
        {
            m_model.Added -= OnAddedController;
            m_model.Removed -= OnAddedController;
        }

        private void FillGrid()
        {
            var builderConfigs = m_model.BuilderConfigs.GroupBuilderConfigs;
            
            foreach (var buildingConfigs in builderConfigs)
            {
                UIBuildingViewModel buildingViewModel = m_uiBuildingsFactory.Create();
                
                buildingViewModel.Initialize(
                    buildingConfigs.BuildingConfigs,
                    buildingConfigs.ViewBuildingConfigs,
                    m_view.GridRoot);
                
                buildingViewModel.BuildingClicked += OnBuildingClicked;
            }
        }
        
        private void OnAddedController(MapController mapController)
        {
            mapController.EmptyTileClicked += OnEmptyTileClicked;
        }
        
        private void OnRemovedController(MapController mapController)
        {
            mapController.EmptyTileClicked -= OnEmptyTileClicked;
        }

        private void OnEmptyTileClicked(TileController tileController)
        {
            m_clickedTile = tileController;
            
            m_view.DoShow();
        }

        private void OnBuildingClicked(EBuildingType buildingType)
        {
            BuildBuilding(buildingType);
            
            m_clickedTile = null;
            
            m_view.DoHide();
        }

        private void BuildBuilding(EBuildingType buildingType)
        {
            if (m_model.TryGetBuildingConfig(buildingType, out BuildingBuilderConfigs configs))
            {
                var buildingPrefab = configs.BuildingPrefab;

                var instance = m_buildingsFactory.Create(buildingPrefab, m_clickedTile.TileTransform);

                m_clickedTile.BuildingViewModel = instance;
                m_clickedTile.TileState = ETileState.FILLED;
            }
        }
    }
}