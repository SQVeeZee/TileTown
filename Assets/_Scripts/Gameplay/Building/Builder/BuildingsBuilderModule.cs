using System;
using _Scripts.Gameplay.Building.Builder.Configs;
using Zenject;

namespace _Scripts.Gameplay.Building.Builder
{
    public interface IBuildingsBuilder
    {
        public event Action<IBuilding> BuildingCreated;
        IBuilding CreateBuilding(EBuildingType buildingType);
    }
    
    public class BuildingsBuilderModule: IBuildingsBuilder
    {
        public event Action<IBuilding> BuildingCreated;
        
        private readonly BuildingsBuilderConfigs m_configs = null;
        private readonly BuildingViewModel.Factory m_buildingsFactory = null;
        
        [Inject]
        public BuildingsBuilderModule(
            BuildingsBuilderConfigs configs,
            BuildingViewModel.Factory buildingsFactory
        )
        {
            m_configs = configs;
            
            m_buildingsFactory = buildingsFactory;
        }


        IBuilding IBuildingsBuilder.CreateBuilding(EBuildingType buildingType)
        {
            if (TryGetBuildingConfig(buildingType, out BuildingBuilderConfigs configs))
            {
                var buildingPrefab = configs.BuildingPrefab;
                
                var buildingView = m_buildingsFactory.Create(buildingPrefab, null);
                var building = buildingView.BuildingViewModel;
                
                BuildingCreated?.Invoke(building);
                
                return building;
            }
            
            return null;
        }

        private bool TryGetBuildingConfig(EBuildingType buildingType, out BuildingBuilderConfigs configs)
        {
            configs = null;
            
            foreach (var buildingsConfig in m_configs.GroupBuilderConfigs)
            {
                if (buildingsConfig.BuildingConfigs.BuildingData.BuildingType == buildingType)
                {
                    configs = buildingsConfig;
                    
                    return true;
                }
            }

            return false;
        }
    }
}