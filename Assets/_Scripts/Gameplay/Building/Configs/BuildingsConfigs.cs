using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Gameplay.Building.Configs
{
    [CreateAssetMenu(fileName = AssetFileName, menuName = AssetFilePath, order = AssetMenuOrder)]
    public class BuildingsConfigs : ScriptableObject
    {
        private const string AssetFileName = nameof(BuildingsConfigs);
        private const string AssetFilePath = nameof(BuildingsConfigs) + "/Data/" + AssetFileName;
        private const int AssetMenuOrder = int.MinValue + 1001;

        [SerializeField] private List<BaseBuildingConfigs> _buildingConfigs = new List<BaseBuildingConfigs>();

        public IReadOnlyList<BaseBuildingConfigs> BuildingsConfigses => _buildingConfigs;
    }
}