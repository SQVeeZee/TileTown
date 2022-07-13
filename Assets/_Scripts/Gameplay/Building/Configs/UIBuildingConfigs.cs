using UnityEngine;

namespace _Scripts.Gameplay.Building.Configs
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]
    public class UIBuildingConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(UIBuildingConfigs);
        private const string ASSET_FILE_PATH = nameof(BuildingsConfigs) + "/Configs/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;

        [SerializeField] private Color m_color = Color.white;

        public Color IconColor => m_color;
    }
}
