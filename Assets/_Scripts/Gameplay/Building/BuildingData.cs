using _Scripts.Gameplay.Building.Configs;
using _Scripts.UI.Building.Impact.Impacts.Configs;
using Zenject;

namespace _Scripts.Gameplay.Building
{
    public class BuildingData: IInitializable
    {
        private readonly BaseBuildingData m_buildingData = null;

        private readonly BuildingImpactsConfigs m_impactsConfigs = null;

        public BaseBuildingData Data => m_buildingData;
        public BuildingImpactsConfigs ImpactsConfigs => m_impactsConfigs;

        public string BuildingName { get; private set; }
        public EBuildingType BuildingType { get; private set; }
        public string BuildingDescription { get; private set; }

        [Inject]
        public BuildingData(
            BaseBuildingConfigs baseBuildingConfigs,
            BuildingImpactsConfigs impactsConfigs
        )
        {
            var buildingData = baseBuildingConfigs.BuildingData;
            m_buildingData = buildingData;

            m_impactsConfigs = impactsConfigs;
        }
        
        void IInitializable.Initialize()
        {
            BuildingName = m_buildingData.BuildingName;
            BuildingType = m_buildingData.BuildingType;
            BuildingDescription = m_buildingData.BuildingDescription;
        }
    }
}