using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Building.Builder.Configs;
using _Scripts.Gameplay.Tile;
using _Scripts.UI.Building;
using _Scripts.UI.Building.Builder;
using _Scripts.Gameplay.Tile.Map;
using Zenject;

namespace _Scripts.Gameplay.Building.Builder
{
    public class BuildingsBuilderViewModel: IInitializable, IDisposable
    {
        private readonly BuildingBuilderModel m_model = null;
        private readonly UIBuildingsBuilderPanel m_view = null;

        private readonly List<UIBuildingViewModel> m_uiBuildings = new List<UIBuildingViewModel>();
        
        private readonly BuildingViewModel.Factory m_buildingsFactory = null;
        private readonly UIBuildingViewModel.Factory m_uiBuildingsFactory = null;

        private readonly MapController m_mapController = null;
        
        private TileController m_clickedTile = null;
        
        
        [Inject]
        public BuildingsBuilderViewModel(
            BuildingBuilderModel model,
            UIBuildingsBuilderPanel view,
            
            BuildingViewModel.Factory buildingsFactory,
            UIBuildingViewModel.Factory uiBuildingsFactory,

            MapController mapController
        )
        {
            m_model = model;
            m_view = view;

            m_buildingsFactory = buildingsFactory;

            m_uiBuildingsFactory = uiBuildingsFactory;
            
            m_mapController = mapController;
        }

        void IInitializable.Initialize()
        {
            m_mapController.EmptyTileClicked += OnEmptyTileClicked;
        }

        void IDisposable.Dispose()
        {
            m_mapController.EmptyTileClicked -= OnEmptyTileClicked;
        }

        private void OnEmptyTileClicked(TileController tileController)
        {
            Validation();
            
            m_clickedTile = tileController;
            
            m_view.DoShow();
        }

        private void Validation()
        {
            if (m_uiBuildings.Count == 0)
            {
                FillGrid();
            }
        }
        
        private void FillGrid()
        {
            var builderConfigs = m_model.BuilderConfigs;

            if (builderConfigs.Count == 0) return;

            foreach (var buildingConfigs in builderConfigs)
            {
                UIBuildingViewModel buildingViewModel = m_uiBuildingsFactory.Create();
                
                buildingViewModel.Initialize(
                    buildingConfigs.BuildingConfigs,
                    buildingConfigs.ViewBuildingConfigs,
                    m_view.GridRoot);

                m_uiBuildings.Add(buildingViewModel);
                
                buildingViewModel.BuildingClicked += OnBuildingClicked;
            }
        }
        
        private void ClearGrid()
        {
            foreach (var uiBuilding in m_uiBuildings)
            {
                uiBuilding.BuildingClicked -= OnBuildingClicked;
                m_uiBuildingsFactory.Remove(uiBuilding);
            }
            
            m_uiBuildings.Clear();
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

                m_clickedTile.SetTileBuilding(instance);
            }
        }
    }
}