using System.Collections.Generic;
using UI.Building.Impact.Configs;
using UnityEngine;

namespace UI.Building.Impact.Impacts.Configs
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]
    public class BuildingImpactsConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(BuildingImpactsConfigs);
        private const string ASSET_FILE_PATH = nameof(BuildingImpactsConfigs) + "/Configs/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;
        
        [SerializeField] private List<BuildingImpactConfigs> m_impactConfigs = new List<BuildingImpactConfigs>();

        public IReadOnlyList<BuildingImpactConfigs> ImpactConfigs => m_impactConfigs;
    }
}