using System.Collections.Generic;
using _Scripts.Gameplay.Building.Builder.Configs;
using Zenject;

namespace _Scripts.Gameplay.Building.Builder
{
    public sealed class BuildingBuilderModel
    {
        private readonly BuildingsBuilderConfigs m_configs = null;
        
        public IReadOnlyList<BuildingBuilderConfigs> BuilderConfigs => m_configs.GroupBuilderConfigs;
        
        [Inject]
        public BuildingBuilderModel(
            BuildingsBuilderConfigs configs
            )
        {
            m_configs = configs;
        }

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