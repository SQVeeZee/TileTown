using System.Collections.Generic;
using _Scripts.UI.Building;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building.Builder
{
    public interface IBuildingsBuilder
    {
        List<UIBuildingViewModel> AddBuildingIcon(Transform parentTransform);
        IBuilding Build(EBuildingType buildingType, Transform parentTransform);
    }
    
    public class BuildingsBuilderViewModel: IBuildingsBuilder
    {
        private readonly BuildingBuilderModel m_model = null;
        private readonly IBuildingBuilder m_builderModule = null;

        [Inject]
        public BuildingsBuilderViewModel(
            BuildingBuilderModel model,
            IBuildingBuilder builderModule
            )
        {
            m_model = model;

            m_builderModule = builderModule;
        }

        List<UIBuildingViewModel> IBuildingsBuilder.AddBuildingIcon(Transform parentTransform)
        {
            List<UIBuildingViewModel> buildingIcons = new List<UIBuildingViewModel>();
            
            var builderConfigs = m_model.BuilderConfigs;
            foreach (var configs in builderConfigs)
            {
                var buildingType = configs.BuildingConfigs.BuildingData.BuildingType;
                var buildingIcon = m_builderModule.CreateBuildingIcon(buildingType, parentTransform);
                
                buildingIcons.Add(buildingIcon);
            }

            return buildingIcons;
        }

        IBuilding IBuildingsBuilder.Build(EBuildingType buildingType, Transform parentTransform)
        {
            var building = m_builderModule.CreateBuilding(buildingType, parentTransform);

            return building;
        }
    }
}
