using System.Collections.Generic;
using _Scripts.Gameplay.Building.Impact.Configs;
using _Scripts.UI.Building.Impact;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Builder
{
    public class UIBuildingImpactsBuilder
    {
        private readonly UIBuildingImpactView.Pool _impactPool = null;
        private readonly List<IUIBuildingImpact> _impacts = new List<IUIBuildingImpact>();
        [Inject]
        public UIBuildingImpactsBuilder(
            UIBuildingImpactView.Pool impactPool
            )
        {
            _impactPool = impactPool;
        }
        
        public List<IUIBuildingImpact> FillActionPanel(BuildingImpactsConfigs buildingImpactsConfigs, Transform parent)
        {
            var impactsConfigs = buildingImpactsConfigs.ImpactConfigs;
            
            if (impactsConfigs.Count == 0) return null;

            foreach (var impactConfig in impactsConfigs)
            {
                var buildingImpact = _impactPool.Spawn(impactConfig, parent);
                
                _impacts.Add(buildingImpact);
            }

            return _impacts;
        }

        public void DeSpawn()
        {
            foreach (var impact in _impacts)
            {
                impact.OnDespawned();
            }

            _impacts.Clear();
        }
    }
}
