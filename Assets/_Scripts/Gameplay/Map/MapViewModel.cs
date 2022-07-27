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
        protected override MapClickMode ClickMode => MapClickMode.Selection;
        
        private readonly UIManager _uiManager = null;
        private readonly ISelectionModule _selectionModule = null;
        private readonly IBuildingsBuilder _buildingsBuilder = null;
        private readonly IUIBuildingImpacts _uiBuildingImpacts = null;

        private ITileViewModel _clickedTile = null;
        
        [Inject]
        public MapViewModel(
            UIManager uiManager,
            ISelectionModule selectionModule,
            IBuildingsBuilder buildingsBuilderViewModel,
            IUIBuildingImpacts uiBuildingImpacts,
            
            IMapClickHandler mapClickHandler,
            IClickModeListener clickModeListener
        ): base(mapClickHandler, clickModeListener)
        {
            _uiManager = uiManager;

            _selectionModule = selectionModule;
            _buildingsBuilder = buildingsBuilderViewModel;
            _uiBuildingImpacts = uiBuildingImpacts;
        }

        void IInitializable.Initialize()
        { 
            Initialize();
            
            _buildingsBuilder.BuildingCreated += OnBuildingCreated;
        }

        void IDisposable.Dispose()
        {
            Dispose();

            _buildingsBuilder.BuildingCreated -= OnBuildingCreated;
        }
        
        private void OnBuildingCreated(IBuilding createdBuilding)
        {
            _clickedTile.Building = createdBuilding;
            
            _selectionModule.UnSelect();
            
            createdBuilding.SetRootTransform(_clickedTile.BuildingContainer);
        }

        protected override void OnClickTile(ITileViewModel tile)
        {
            OnTileClicked(tile);
        }

        private void OnTileClicked(ITileViewModel tile)
        {
            if (tile == null) return;
            
            _clickedTile = tile;
            var isEmpty = _clickedTile.IsEmpty;
            
            UpdateTileSelection(_clickedTile);
            ShowScreenDependsOnTileState(isEmpty);
            
            if (!isEmpty)
            {
                _uiBuildingImpacts.SetBuildingImpactsConfigs(tile.Building.ImpactsConfigs);
            }
        }

        private void UpdateTileSelection(ITileViewModel clickedTile)
        {
            _selectionModule.Select(clickedTile);
        }

        private void ShowScreenDependsOnTileState(bool isEmpty) =>
            _uiManager.ShowScreenByType(isEmpty ? EScreenType.Builder : EScreenType.Impacts);
    }
}
