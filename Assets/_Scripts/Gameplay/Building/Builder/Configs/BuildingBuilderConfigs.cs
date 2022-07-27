using _Scripts.Gameplay.Building.Configs;
using UnityEngine;

namespace _Scripts.Gameplay.Building.Builder.Configs
{
    [CreateAssetMenu(fileName = AssetFileName, menuName = AssetFilePath, order = AssetMenuOrder)]

    public class BuildingBuilderConfigs : ScriptableObject
    {
        private const string AssetFileName = nameof(BuildingBuilderConfigs);
        private const string AssetFilePath = nameof(BuildingBuilderConfigs) + "/Data/" + AssetFileName;
        private const int AssetMenuOrder = int.MinValue + 1001;

        [SerializeField] private BaseBuildingConfigs _buildingConfigs = null;
        [SerializeField] private GameObject _buildingPrefab = null;

        public BaseBuildingConfigs BuildingConfigs => _buildingConfigs;
        public GameObject BuildingPrefab => _buildingPrefab;
    }
}
