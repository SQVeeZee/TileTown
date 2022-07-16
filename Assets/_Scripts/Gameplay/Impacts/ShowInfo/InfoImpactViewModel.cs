using _Scripts.Gameplay.Building.Impact.Impacts;
using _Scripts.Gameplay.Tile;
using _Scripts.Gameplay.Tile.Map;
using Zenject;

namespace _Scripts.Gameplay.Building.Impact.Info
{
    public class InfoImpactViewModel : BaseImpactViewModel
    {
        private readonly UIBuildingInfoPanel m_view = null;
        private readonly InfoImpactModel m_model = null;

        private readonly MapController m_mapController = null;

        protected override EImpactType m_impactType => m_model.ImpactType;

        [Inject]
        public InfoImpactViewModel(
            InfoImpactModel model,
            UIBuildingInfoPanel view,
            ImpactsController impactsController,
            MapController mapController
        ) : base(impactsController)
        {
            m_view = view;
            m_model = model;

            m_mapController = mapController;
        }

        protected override void Initialize()
        {
            m_view.CloseButtonPressed += OnCloseButtonPressed;
        }

        protected override void Dispose()
        {
            m_view.CloseButtonPressed -= OnCloseButtonPressed;
        }

        protected override void DoImpact()
        {
            var selectedTile = m_mapController.SelectedTile;

            OnUpdateSelectedTile(selectedTile);
        }

        private void OnUpdateSelectedTile(TileController selectedTile)
        {
            if (selectedTile.TileState == ETileState.FILLED)
            {
                var building = selectedTile.BuildingViewModel;
                var buildingConfigs = building.Configs;

                m_view.Initialize(
                    buildingConfigs.BuildingName,
                    buildingConfigs.BuildingType.ToString(),
                    buildingConfigs.BuildingDescription
                );

                m_view.DoShow();
            }
        }

        private void OnCloseButtonPressed()
        {
            m_view.DoHide();
        }
    }
}
