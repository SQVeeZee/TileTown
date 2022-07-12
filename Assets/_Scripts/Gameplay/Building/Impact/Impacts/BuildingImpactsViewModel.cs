using System;
using System.Collections.Generic;
using Gameplay.Map;
using Gameplay.Tile;
using UI.Building.Impact.Impacts.Configs;
using UnityEngine;
using Zenject;

namespace UI.Building.Impact.Impacts
{
    public class BuildingImpactsViewModel: IInitializable, IDisposable
    {
        public event Action<EBuildingImpactType, TileController> ImpactClicked = null;
        
        private readonly BuildingImpactsModel m_model = null;
        private readonly UIBuildingImpactsPanel m_view = null;
        private readonly UIBuildingImpactViewModel.Pool m_impactPool = null;
        
        private TileController m_clickedTile = null;

        private List<UIBuildingImpactViewModel> m_impacts;
        
        [Inject]
        BuildingImpactsViewModel(
            BuildingImpactsModel model,
            UIBuildingImpactsPanel view,
            UIBuildingImpactViewModel.Pool impactPool
        )
        {
            m_model = model;
            m_view = view;

            m_impactPool = impactPool;
        }

        void IInitializable.Initialize()
        {
            m_model.Added += OnAddedMapController;
            m_model.Removed += OnRemovedMapController;
        }
        
        void IDisposable.Dispose()
        {
            m_model.Added -= OnAddedMapController;
            m_model.Removed -= OnRemovedMapController;
        }

        private void OnAddedMapController(MapController controller)
        {
            controller.FilledTileClicked += OnFilledTileClicked;
        }
        
        private void OnRemovedMapController(MapController controller)
        {
            controller.FilledTileClicked -= OnFilledTileClicked;
        }

        private void OnFilledTileClicked(TileController tileController)
        {
            var building = tileController.BuildingViewModel;

            m_model.ImpactsConfigs = building.ImpactConfigs;

            FillActionPanel(m_model.ImpactsConfigs);

            m_clickedTile = tileController;
            
            m_view.DoShow();
        }
        
        private void FillActionPanel(BuildingImpactsConfigs impactsConfigs)
        {
            var configs = impactsConfigs.ImpactConfigs;
            
            if (configs.Count == 0) return;

            m_impacts = new List<UIBuildingImpactViewModel>();
            
            foreach (var impactConfig in configs)
            {
                var instance = m_impactPool.Spawn(impactConfig, m_view.ImpactParent);
                
                m_impacts.Add(instance);
                
                instance.ImpactClicked += OnImpactClicked;
            }
        }

        private void OnImpactClicked(EBuildingImpactType buildingImpactType)
        {
            Debug.Log(buildingImpactType);
            m_view.DoHide();
            
            ImpactClicked?.Invoke(buildingImpactType, m_clickedTile);

            m_clickedTile = null;

            ClearImpacts();
        }

        private void ClearImpacts()
        {
            foreach (var impact in m_impacts)
            {
                impact.ImpactClicked -= OnImpactClicked;
                
                m_impactPool.Despawn(impact);
            }

            m_impacts.Clear();
        }
    }
}