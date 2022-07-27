using System.Collections.Generic;
using _Scripts.Gameplay.Building.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Builder
{
    public class IuiBuildingsBuilderModule: IUIBuildingsBuilderModule
    {
        private readonly UIBuildingView.Factory _uiBuildingsFactory = null;
        private readonly UIBuildingsConfigs _buildingConfigs = null;

        [Inject]
        public IuiBuildingsBuilderModule(
            UIBuildingsConfigs buildingConfigs,
            UIBuildingView.Factory uiBuildingFactory
        )
        {
            _buildingConfigs = buildingConfigs;

            _uiBuildingsFactory = uiBuildingFactory;
        }

        List<UIBuildingView> IUIBuildingsBuilderModule.CreateAndGetBuildingIcons(Transform parentTransform)
        {
            List<UIBuildingView> buildingIcons = new List<UIBuildingView>();

            var builderConfigs = _buildingConfigs.UIBuildingConfigs;
            
            foreach (var configs in builderConfigs)
            {
                var buildingView = _uiBuildingsFactory.Create();

                buildingView.Initialize(configs);
                buildingView.SetTransform(parentTransform);
                
                buildingIcons.Add(buildingView);
            }

            return buildingIcons;
        }
    }
}