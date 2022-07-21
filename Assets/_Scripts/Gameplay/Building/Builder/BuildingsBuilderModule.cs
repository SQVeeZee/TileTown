using _Scripts.Gameplay.Building.Builder.Configs;
using _Scripts.UI.Building;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building.Builder
{
    public interface IBuildingBuilder
    {
        IBuilding CreateBuilding(EBuildingType buildingType, Transform parentTransform);
        UIBuildingViewModel CreateBuildingIcon(EBuildingType buildingType, Transform parentTransform);
    }
    
    public class BuildingsBuilderModule: IBuildingBuilder
    {
        private readonly BuildingBuilderModel m_model = null;

        private readonly BuildingViewModel.Factory m_buildingsFactory = null;
        private readonly UIBuildingViewModel.Factory m_uiBuildingsFactory = null;
        
        [Inject]
        public BuildingsBuilderModule(
            BuildingBuilderModel model,
            BuildingViewModel.Factory buildingsFactory,
            UIBuildingViewModel.Factory uiBuildingFactory
        )
        {
            m_model = model;

            m_buildingsFactory = buildingsFactory;
            m_uiBuildingsFactory = uiBuildingFactory;
        }

        IBuilding IBuildingBuilder.CreateBuilding(EBuildingType buildingType, Transform parentTransform)
        {
            if (m_model.TryGetBuildingConfig(buildingType, out BuildingBuilderConfigs configs))
            {
                var buildingPrefab = configs.ViewBuildingConfigs;
                
                var building = m_buildingsFactory.Create(buildingPrefab, parentTransform);

                return building.Building;
            }
            
            return null;

        }

        UIBuildingViewModel IBuildingBuilder.CreateBuildingIcon(EBuildingType buildingType, Transform parentTransform)
        {
            if (m_model.TryGetBuildingConfig(buildingType, out BuildingBuilderConfigs configs))
            {
                var buildingViewModel = m_uiBuildingsFactory.Create().UiBuildingViewModel;
                var baseBuildingConfigs = configs.BuildingConfigs;
                
                buildingViewModel.Initialize(baseBuildingConfigs, parentTransform);
                
                return buildingViewModel;
            }
            
            return null;
        }
    }
}