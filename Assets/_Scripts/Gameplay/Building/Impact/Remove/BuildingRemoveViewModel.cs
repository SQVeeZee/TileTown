using Gameplay.Tile;
using UI.Building.Impact;
using UI.Building.Impact.Impacts;
using Zenject;

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
