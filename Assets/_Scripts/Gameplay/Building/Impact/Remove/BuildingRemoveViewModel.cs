using _Scripts.Gameplay.Tile;
using _Scripts.UI.Building.Impact;
using _Scripts.UI.Building.Impact.Impacts;
using Zenject;

namespace _Scripts.Gameplay.Building.Impact.Remove
{
    public class BuildingRemoveViewModel : BaseImpact
    {
        public override EBuildingImpactType ImpactType => EBuildingImpactType.REMOVE;

        [Inject]
        public BuildingRemoveViewModel(
            BuildingImpactsViewModel impactsViewModel
        )
            : base(impactsViewModel)
        {
        }

        protected override void DoImpact(TileController tileController)
        {
            var building = tileController.BuildingViewModel;

            // building.Remove();
        }
    }
}