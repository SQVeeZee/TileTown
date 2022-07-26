using System.Collections.Generic;
using _Scripts.UI.Building.Impacts.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Impacts.Builder
{
    public class UIBuildingImpactsBuilder
    {
        private readonly UIBuildingImpactView.Pool m_impactPool = null;
        
        [Inject]
        public UIBuildingImpactsBuilder(
            UIBuildingImpactView.Pool impactPool
            )
        {
            m_impactPool = impactPool;
        }
        
        public List<IUIBuildingImpact> FillActionPanel(BuildingImpactsConfigs buildingImpactsConfigs, Transform parent)
        {
            var impactsConfigs = buildingImpactsConfigs.ImpactConfigs;
            
            if (impactsConfigs.Count == 0) return null;
            
            List<IUIBuildingImpact> impacts = new List<IUIBuildingImpact>();
            
            foreach (var impactConfig in impactsConfigs)
            {
                var buildingImpact = m_impactPool.Spawn(impactConfig, parent);
                
                impacts.Add(buildingImpact);
            }

            return impacts;
        }
    }
}
