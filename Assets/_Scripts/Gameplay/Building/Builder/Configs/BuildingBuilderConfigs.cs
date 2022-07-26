using _Scripts.Gameplay.Building.Configs;
using _Scripts.UI.Building.Configs;
using UnityEngine;

namespace _Scripts.Gameplay.Building.Builder.Configs
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]

    public class BuildingBuilderConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(BuildingBuilderConfigs);
        private const string ASSET_FILE_PATH = nameof(BuildingBuilderConfigs) + "/Data/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;

        [SerializeField] private BaseBuildingConfigs m_buildingConfigs = null;
        [SerializeField] private GameObject m_buildingPrefab = null;

        public BaseBuildingConfigs BuildingConfigs => m_buildingConfigs;
        public GameObject BuildingPrefab => m_buildingPrefab;
    }
}
