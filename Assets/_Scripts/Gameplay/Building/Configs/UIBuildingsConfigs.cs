using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Gameplay.Building.Configs
{
    [CreateAssetMenu(fileName = AssetFileName, menuName = AssetFilePath, order = AssetMenuOrder)]
    public class UIBuildingsConfigs : ScriptableObject
    {
        private const string AssetFileName = nameof(UIBuildingsConfigs);
        private const string AssetFilePath = nameof(UIBuildingsConfigs) + "/" + AssetFileName;
        private const int AssetMenuOrder = int.MinValue + 1001;

        [SerializeField] private List<UIBuildingConfigs> _buildingConfigs;

        public IReadOnlyList<UIBuildingConfigs> UIBuildingConfigs => _buildingConfigs;
    }
}
