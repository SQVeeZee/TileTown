using System;
using _Scripts.Gameplay.Building.Builder.Configs;
using Zenject;

namespace _Scripts.Gameplay.Building.Builder
{
    public class BuildingsBuilderModule: IBuildingsBuilder
    {
        public event Action<IBuilding> BuildingCreated;
        
        private readonly BuildingsBuilderConfigs _configs = null;
        private readonly BuildingViewModel.Factory _buildingsFactory = null;
        
        [Inject]
        public BuildingsBuilderModule(
            BuildingsBuilderConfigs configs,
            BuildingViewModel.Factory buildingsFactory
        )
        {
            _configs = configs;
            
            _buildingsFactory = buildingsFactory;
        }


        IBuilding IBuildingsBuilder.CreateBuilding(EBuildingType buildingType)
        {
            if (TryGetBuildingConfig(buildingType, out BuildingBuilderConfigs configs))
            {
                var buildingPrefab = configs.BuildingPrefab;
                
                var buildingView = _buildingsFactory.Create(buildingPrefab, null);
                var building = buildingView.BuildingViewModel;
                
                BuildingCreated?.Invoke(building);
                
                return building;
            }
            
            return null;
        }

        private bool TryGetBuildingConfig(EBuildingType buildingType, out BuildingBuilderConfigs configs)
        {
            configs = null;
            
            foreach (var buildingsConfig in _configs.GroupBuilderConfigs)
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