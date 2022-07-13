using _Scripts.Gameplay.Building;
using _Scripts.Gameplay.Building.Configs;
using _Scripts.UI.Building.Impact.Impacts.Configs;
using Zenject;

public class BuildingModel
{
    private readonly BaseBuildingConfigs m_baseBuildingConfigs = null;

    private readonly BuildingImpactsConfigs m_impactsConfigs = null;

    public BaseBuildingConfigs Configs => m_baseBuildingConfigs;
    public BuildingImpactsConfigs ImpactsConfigs => m_impactsConfigs;
    
    public string BuildingName { get; }
    public EBuildingType BuildingType { get; }
    public string BuildingDescription { get; }

    [Inject]
    public BuildingModel(
        BaseBuildingConfigs baseBuildingConfigs,
        BuildingImpactsConfigs impactsConfigs
    )
    {
        BuildingName = baseBuildingConfigs.BuildingName;
        BuildingType = baseBuildingConfigs.BuildingType;
        BuildingDescription = baseBuildingConfigs.BuildingDescription;

        m_baseBuildingConfigs = baseBuildingConfigs;
        
        m_impactsConfigs = impactsConfigs;
    }
}
