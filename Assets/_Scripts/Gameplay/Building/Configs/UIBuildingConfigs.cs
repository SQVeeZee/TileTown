using System;
using _Scripts.Gameplay.Building.Configs;
using UnityEngine;

namespace _Scripts.UI.Building.Configs
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]
    public class UIBuildingConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(UIBuildingConfigs);
        private const string ASSET_FILE_PATH = nameof(UIBuildingsConfigs) + "/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;

        [SerializeField] private UIBuildingIconData m_buildingIconData = null;
        
        public UIBuildingIconData BuildingIconData => m_buildingIconData;
    }

    [Serializable]
    public class UIBuildingIconData
    {
        [SerializeField] private BaseBuildingConfigs m_baseBuildingConfigs = null;
        [SerializeField] private Color m_color = Color.white;
        
        public BaseBuildingConfigs BaseBuildingConfigs => m_baseBuildingConfigs;
        public Color IconColor => m_color;
    }
}
