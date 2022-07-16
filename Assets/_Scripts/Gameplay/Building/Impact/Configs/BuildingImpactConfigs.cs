using _Scripts.Gameplay.Building.Impact;
using _Scripts.UI.Building.Impact.Impacts.Configs;
using UnityEngine;

namespace _Scripts.UI.Building.Impact.Configs
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]
    public class BuildingImpactConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(BuildingImpactConfigs);
        private const string ASSET_FILE_PATH = nameof(BuildingImpactsConfigs) + "/Configs/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;

        [SerializeField] private EImpactType m_buildImpactType = EImpactType.NONE;
        [SerializeField] private Color m_color = Color.white;
        [SerializeField] private string m_impactName = default;
        
        public EImpactType BuildImpactType => m_buildImpactType;
        public Color ImpactColor => m_color;
        public string ImpactName => m_impactName;
    }
}
