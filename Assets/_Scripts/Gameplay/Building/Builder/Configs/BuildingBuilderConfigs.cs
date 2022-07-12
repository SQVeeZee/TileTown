using Gameplay.Building.Configs;
using UnityEngine;

namespace Gameplay.Building.Builder
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]

    public class BuildingBuilderConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(BuildingBuilderConfigs);
        private const string ASSET_FILE_PATH = nameof(BuildingBuilderConfigs) + "/Configs/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;

        [SerializeField] private BaseBuildingConfigs m_buildingConfigs = null;
        [SerializeField] private UIBuildingConfigs m_viewBuildingConfigs = null;
        [SerializeField] private GameObject m_buildingPrefab = null;

        public BaseBuildingConfigs BuildingConfigs => m_buildingConfigs;
        public UIBuildingConfigs ViewBuildingConfigs => m_viewBuildingConfigs;
        public GameObject BuildingPrefab => m_buildingPrefab;
    }
}
