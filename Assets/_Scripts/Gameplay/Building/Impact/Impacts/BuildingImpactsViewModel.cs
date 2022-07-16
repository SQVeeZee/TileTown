using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Building;
using _Scripts.Gameplay.Building.Impact;
using _Scripts.Gameplay.Building.Impact.Impacts;
using _Scripts.Gameplay.Tile;
using _Scripts.Gameplay.Tile.Map;
using _Scripts.UI.Building.Impact.Impacts.Configs;
using Zenject;

namespace _Scripts.UI.Building.Impact.Impacts
{
    public class BuildingImpactsViewModel: IInitializable,IDisposable
    {
        public event Action<EImpactType> ImpactClicked = null;
        
        private readonly BuildingImpactsModel m_model = null;
        private readonly UIBuildingImpactsPanel m_view = null;
        private readonly UIBuildingImpactViewModel.Pool m_impactPool = null;
        
        private readonly MapController m_mapController = null;
        
        private List<UIBuildingImpactViewModel> m_impacts;
        
        [Inject]
        BuildingImpactsViewModel(
            BuildingImpactsModel model,
            UIBuildingImpactsPanel view,
            UIBuildingImpactViewModel.Pool impactPool,
            
            MapController mapController
        )
        {
            m_model = model;
            m_view = view;

            m_impactPool = impactPool;

            m_mapController = mapController;
        }

        void IInitializable.Initialize()
        {
            m_mapController.UpdateSelectedTile += OnUpdateSelectedTile;
        }

        void IDisposable.Dispose()
        {
            m_mapController.UpdateSelectedTile -= OnUpdateSelectedTile;
        }

        private void OnUpdateSelectedTile(TileController previousTile, TileController selectedTile)
        {
            if(CanShowBuildingPanel(selectedTile))
            {
                ShowBuildingPanel(selectedTile);
            }
        }

        private bool CanShowBuildingPanel(TileController selectedTile)
        {
            if (m_mapController.InteractionState.HasFlag(EMapInteractionState.IMPACTS)
                && selectedTile.TileState == ETileState.FILLED)
            {
                return true;
            }

            return false;
        }

        private void ShowBuildingPanel(TileController selectedTile)
        {
            var building = selectedTile.BuildingViewModel;
            
            OnEnabledBuildingImpactsView(building);
        }
        
        private void OnEnabledBuildingImpactsView(BuildingViewModel building)
        {
            var clickedBuilding = building;

            m_model.ImpactsConfigs = clickedBuilding.ImpactConfigs;

            FillActionPanel(m_model.ImpactsConfigs);
            
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

        private void OnImpactClicked(EImpactType impactType)
        {
            m_view.DoHide();
            
            ImpactClicked?.Invoke(impactType);

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