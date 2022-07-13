using _Scripts.Gameplay.Building.Impact;
using _Scripts.UI.Building.Impact.Configs;
using JetBrains.Annotations;

namespace _Scripts.UI.Building.Impact
{
    [UsedImplicitly]
    public class UIBuildingImpactModel
    {
        private BuildingImpactConfigs m_configs = null;

        public EBuildingImpactType ImpactType => m_configs.BuildImpactType;
        
        public void Initialize(BuildingImpactConfigs impactConfigs)
        {
            m_configs = impactConfigs;
        }
    }
}
