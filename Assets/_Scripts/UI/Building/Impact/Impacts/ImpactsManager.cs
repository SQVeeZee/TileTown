using System;
using _Scripts.Gameplay.Building.Impacts.Info;
using _Scripts.Gameplay.Building.Impacts.Move;
using _Scripts.Gameplay.Building.Impacts.Remove;
using _Scripts.Gameplay.Tile;
using _Scripts.Gameplay.Tile.Map.Selection;
using _Scripts.UI.Building.Impacts;
using _Scripts.UI.Screens;
using Zenject;

namespace _Scripts.UI.Building.Impact.Impacts
{
    public class ImpactsManager : IInitializable, IDisposable
    {
        private readonly UIManager _uiManager = null;
        private readonly ISelectionModule _selectionModule = null;

        private readonly IUIBuildingImpacts _buildingImpacts = null;
        private readonly IRemoveImpactModule _removeImpactModule = null;
        private readonly IMoveImpact _moveImpact = null;
        private readonly IInfoImpactModule _showInfoImpactModule = null;

        [Inject]
        public ImpactsManager(
            UIManager uiManager,
            ISelectionModule selectionModule,

            IUIBuildingImpacts buildingImpacts,
            
            IRemoveImpactModule removeImpactModule,
            IMoveImpact moveImpact,
            IInfoImpactModule showInfoImpactModule
        )
        {
            _uiManager = uiManager;
            _selectionModule = selectionModule;

            _buildingImpacts = buildingImpacts;
            
            _removeImpactModule = removeImpactModule;
            _moveImpact = moveImpact;
            _showInfoImpactModule = showInfoImpactModule;
        }

        void IInitializable.Initialize()
        {
            _buildingImpacts.ImpactClicked += OnImpactClicked;
        }

        void IDisposable.Dispose()
        {
            _buildingImpacts.ImpactClicked -= OnImpactClicked;
        }

        private void OnImpactClicked(EImpactType impactType)
        {
            ChooseImpactDependsOnType(impactType);
        }

        private void ChooseImpactDependsOnType(EImpactType impactType)
        {
            var selectedTile = _selectionModule.SelectedTile;
            
            switch (impactType)
            {
                case EImpactType.None:
                    break;
                case EImpactType.Remove:
                    OnRemoveBuilding(selectedTile);
                    break;
                case EImpactType.Move:
                    OnMoveBuilding(selectedTile);
                    break;
                case EImpactType.ShowInfo:
                    OnShowInfoBuilding(selectedTile);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(impactType), impactType, null);
            }
        }

        private void OnRemoveBuilding(ITileViewModel selectedTile)
        {
            _removeImpactModule.DoImpact(selectedTile);
        }

        private void OnMoveBuilding(ITileViewModel selectedTile)
        {
            _moveImpact.DoImpact(selectedTile);
        }

        private void OnShowInfoBuilding(ITileViewModel selectedTile)
        {
            _showInfoImpactModule.DoImpact(selectedTile);
            
            _uiManager.ShowScreenByType(EScreenType.BuildingInfo);
        }
    }
}