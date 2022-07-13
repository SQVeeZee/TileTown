using JetBrains.Annotations;
using UI.Building.Impact.Configs;

namespace UI.Building.Impact
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
