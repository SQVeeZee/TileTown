using Gameplay.Building;
using Gameplay.Tile;
using UI.Building.Impact;
using UI.Building.Impact.Impacts;

public abstract class BaseImpact : IImpact
{
    private readonly BuildingImpactsViewModel m_impactsViewModel = null;

    protected BuildingViewModel m_building = null;
    
    public abstract EBuildingImpactType ImpactType { get; }
    protected abstract void DoImpact(TileController tileController);

    protected BaseImpact(
        BuildingImpactsViewModel impactsViewModel
    )
    {
        m_impactsViewModel = impactsViewModel;
    }
    
    protected void Initialize()
    {
        m_impactsViewModel.ImpactClicked += OnImpactClicked;
    }

    protected void Dispose()
    {
        m_impactsViewModel.ImpactClicked -= OnImpactClicked;
    }

    private void OnImpactClicked(EBuildingImpactType impactType, TileController tileController)
    {
        if (impactType == ImpactType)
        {
            m_building = tileController.BuildingViewModel;
            
            DoImpact(tileController);
        }
    }
}
