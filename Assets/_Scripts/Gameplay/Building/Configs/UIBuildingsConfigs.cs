using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.UI.Building.Configs
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]
    public class UIBuildingsConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(UIBuildingsConfigs);
        private const string ASSET_FILE_PATH = nameof(UIBuildingsConfigs) + "/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;

        [SerializeField] private List<UIBuildingConfigs> m_buildingConfigs;

        public IReadOnlyList<UIBuildingConfigs> UIBuildingConfigs => m_buildingConfigs;
    }
}
