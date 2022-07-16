using _Scripts.Gameplay.Building.Impact.Impacts;
using _Scripts.Gameplay.Tile.Map;
using Zenject;

namespace _Scripts.Gameplay.Building.Impact.Remove
{
    public class RemoveImpactViewModel : BaseImpactViewModel
    {
        private readonly RemoveImpactModel m_model = null;
        private readonly MapController m_mapController = null;

        protected override EImpactType m_impactType => m_model.ImpactType;
        
        protected override void Initialize() { }
        protected override void Dispose() { }
        
        [Inject]
        public RemoveImpactViewModel(
            RemoveImpactModel model,
            ImpactsController impactsController,
            MapController mapController
        ): base(impactsController)
        {
            m_model = model;

            m_mapController = mapController;
        }

        private void RemoveBuilding()
        {
            BuildingViewModel selectedBuilding = m_mapController.SelectedTile.BuildingViewModel;
            
            selectedBuilding.Remove();
        }

        protected override void DoImpact()
        {
            RemoveBuilding();
        }
    }
}