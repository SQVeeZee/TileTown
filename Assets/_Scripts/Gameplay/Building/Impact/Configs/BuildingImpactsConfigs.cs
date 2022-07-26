using System.Collections.Generic;
using _Scripts.UI.Building.Impacts.Configs;
using UnityEngine;

namespace _Scripts.UI.Building.Impacts.Configs
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]
    public class BuildingImpactsConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(BuildingImpactsConfigs);
        private const string ASSET_FILE_PATH = nameof(BuildingImpactsConfigs) + "/Data/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;
        
        [SerializeField] private List<BuildingImpactConfigs> m_impactConfigs = new List<BuildingImpactConfigs>();

        public IReadOnlyList<BuildingImpactConfigs> ImpactConfigs => m_impactConfigs;
    }
}