using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Gameplay.Building.Configs
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]
    public class BuildingsConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(BuildingsConfigs);
        private const string ASSET_FILE_PATH = nameof(BuildingsConfigs) + "/Data/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;

        [SerializeField] private List<BaseBuildingConfigs> m_buildingConfigs = new List<BaseBuildingConfigs>();

        public IReadOnlyList<BaseBuildingConfigs> BuildingsConfigses => m_buildingConfigs;
    }
}