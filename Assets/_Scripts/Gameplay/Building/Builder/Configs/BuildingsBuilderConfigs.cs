using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Building.Builder
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]

    public class BuildingsBuilderConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(BuildingsBuilderConfigs);
        private const string ASSET_FILE_PATH = nameof(BuildingBuilderConfigs) + "/Configs/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;

        [SerializeField] private List<BuildingBuilderConfigs> m_builderConfigs;

        public IReadOnlyList<BuildingBuilderConfigs> GroupBuilderConfigs => m_builderConfigs;
    }
}