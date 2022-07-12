using Gameplay.Map;
using Zenject;

namespace Gameplay.Building.Builder
{
    public class BuildingBuilderModel: BaseSimpleModel<MapController>
    {
        private readonly BuildingsBuilderConfigs m_configs = null;

        public BuildingsBuilderConfigs BuilderConfigs => m_configs;
        
        [Inject]
        public BuildingBuilderModel(
            BuildingsBuilderConfigs configs
        )
        {
            m_configs = configs;
        }

        public int BuildingsCount => m_configs.GroupBuilderConfigs.Count;

        public bool TryGetBuildingConfig(EBuildingType buildingType, out BuildingBuilderConfigs configs)
        {
            configs = null;
            
            foreach (var buildingsConfig in m_configs.GroupBuilderConfigs)
            {
                if (buildingsConfig.BuildingConfigs.BuildingType == buildingType)
                {
                    configs = buildingsConfig;
                    
                    return true;
                }
            }

            return false;
        }
    }
}