using UnityEngine;

namespace _Scripts.Gameplay.Building.Configs
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]
    public class BaseBuildingConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(BaseBuildingConfigs);
        private const string ASSET_FILE_PATH = nameof(BuildingsConfigs) + "/Configs/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;

        [Header("Info")]
        [SerializeField] private string m_buildingName = default;
        [SerializeField] private EBuildingType m_buildingType = default;
        
        [Multiline(5)]
        [SerializeField] private string m_buildingDescription = default;

        public string BuildingName => m_buildingName;
        public EBuildingType BuildingType => m_buildingType;
        public string BuildingDescription => m_buildingDescription;
    }
}
