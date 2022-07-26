using System;
using _Scripts.Gameplay.Building;
using _Scripts.Gameplay.Building.Builder;
using _Scripts.Gameplay.Tile.Map.Click;
using _Scripts.Gameplay.Tile.Map.Selection;
using _Scripts.UI.Building.Impacts;
using _Scripts.UI.Screens;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map
{
    public class MapViewModel: BaseMapClickListener, IInitializable, IDisposable
    {
        protected override MapClickMode ClickMode => MapClickMode.SELECTION;
        
        private readonly UIManager m_uiManager = null;
        private readonly ISelectionModule m_selectionModule = null;
        private readonly IBuildingsBuilder m_buildingsBuilder = null;
        private readonly IUIBuildingImpacts m_iuiBuildingImpacts = null;

        private ITileViewModel m_clickedTile = null;
        
        [Inject]
        public MapViewModel(
            UIManager uiManager,
            ISelectionModule selectionModule,
            IBuildingsBuilder buildingsBuilderViewModel,
            IUIBuildingImpacts iuiBuildingImpacts,
            
            IMapClickHandler mapClickHandler,
            IClickModeListener clickModeListener
        ): base(mapClickHandler, clickModeListener)
        {
            m_uiManager = uiManager;

            m_selectionModule = selectionModule;
            m_buildingsBuilder = buildingsBuilderViewModel;
            m_iuiBuildingImpacts = iuiBuildingImpacts;
        }

        void IInitializable.Initialize()
        { 
            Initialize();
            
            m_buildingsBuilder.BuildingCreated += OnBuildingCreated;
        }

        void IDisposable.Dispose()
        {
            Dispose();

            m_buildingsBuilder.BuildingCreated -= OnBuildingCreated;
        }
        
        private void OnBuildingCreated(IBuilding createdBuilding)
        {
            m_clickedTile.Building = createdBuilding;
            
            m_selectionModule.UnSelect();
            
            createdBuilding.SetRootTransform(m_clickedTile.BuildingContainer);
        }

        protected override void OnClickTile(ITileViewModel tile)
        {
            OnTileClicked(tile);
        }

        private void OnTileClicked(ITileViewModel tile)
        {
            if (tile == null) return;
            
            m_clickedTile = tile;
            var tileState = m_clickedTile.IsEmpty;
            
            UpdateTileSelection(m_clickedTile);
            ShowScreenDependsOnTileState(tileState);
            if (!tile.IsEmpty)
            {
                m_iuiBuildingImpacts.SetBuildingImpactsConfigs(tile.Building.ImpactsConfigs);
            }
        }

        private void UpdateTileSelection(ITileViewModel clickedTile)
        {
            m_selectionModule.Select(clickedTile);
        }

        private void ShowScreenDependsOnTileState(bool isEmpty) =>
            m_uiManager.ShowScreenByType(isEmpty ? EScreenType.BUILDER : EScreenType.IMPACTS);
    }
}
