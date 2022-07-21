using System;
using UnityEngine;

namespace _Scripts.Gameplay.Building.Configs
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]
    public class BaseBuildingConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(BaseBuildingConfigs);
        private const string ASSET_FILE_PATH = nameof(BuildingsConfigs) + "/Data/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;

        [SerializeField] private BaseBuildingData m_buildingData = null;
        [SerializeField] private UIBuildingData m_uiData = null;

        public BaseBuildingData BuildingData => m_buildingData;
        public UIBuildingData UIData => m_uiData;
    }

    [Serializable]
    public class BaseBuildingData
    {
        [Header("Info")]
        [SerializeField] private string m_buildingName = default;
        [SerializeField] private EBuildingType m_buildingType = default;
        
        [Multiline(5)]
        [SerializeField] private string m_buildingDescription = default;
        
        public string BuildingName => m_buildingName;
        public EBuildingType BuildingType => m_buildingType;
        public string BuildingDescription => m_buildingDescription;
    }

    [Serializable]
    public class UIBuildingData
    {
        [SerializeField] private Color m_buildingColor = Color.white;

        public Color BuildingColor => m_buildingColor;
    }
}
