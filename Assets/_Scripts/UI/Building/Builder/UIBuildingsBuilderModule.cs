using System.Collections.Generic;
using _Scripts.UI.Building.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Builder
{
    public interface IUIBuildingsBuilderModule
    {
        List<UIBuildingView> CreateAndGetBuildingIcons(Transform parentTransform);
    }
    
    public class UIBuildingsBuilderModule: IUIBuildingsBuilderModule
    {
        private readonly UIBuildingView.Factory m_uiBuildingsFactory = null;
        private readonly UIBuildingsConfigs m_buildingConfigs = null;

        [Inject]
        public UIBuildingsBuilderModule(
            UIBuildingsConfigs buildingConfigs,
            UIBuildingView.Factory uiBuildingFactory
        )
        {
            m_buildingConfigs = buildingConfigs;

            m_uiBuildingsFactory = uiBuildingFactory;
        }

        List<UIBuildingView> IUIBuildingsBuilderModule.CreateAndGetBuildingIcons(Transform parentTransform)
        {
            List<UIBuildingView> buildingIcons = new List<UIBuildingView>();

            var builderConfigs = m_buildingConfigs.UIBuildingConfigs;
            
            foreach (var configs in builderConfigs)
            {
                var buildingView = m_uiBuildingsFactory.Create();

                buildingView.Initialize(configs);
                buildingView.SetTransform(parentTransform);
                
                buildingIcons.Add(buildingView);
            }

            return buildingIcons;
        }
    }
}