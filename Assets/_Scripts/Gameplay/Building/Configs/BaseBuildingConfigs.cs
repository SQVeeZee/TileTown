using System;
using UnityEngine;

namespace _Scripts.Gameplay.Building.Configs
{
    [CreateAssetMenu(fileName = AssetFileName, menuName = AssetFilePath, order = AssetMenuOrder)]
    public class BaseBuildingConfigs : ScriptableObject
    {
        private const string AssetFileName = nameof(BaseBuildingConfigs);
        private const string AssetFilePath = nameof(BuildingsConfigs) + "/Data/" + AssetFileName;
        private const int AssetMenuOrder = int.MinValue + 1001;

        [SerializeField] private BaseBuildingData _buildingData = null;

        public BaseBuildingData BuildingData => _buildingData;
    }

    [Serializable]
    public class BaseBuildingData
    {
        [Header("Info")]
        [SerializeField] private string _buildingName = default;
        [SerializeField] private EBuildingType _buildingType = default;
        
        [Multiline(5)]
        [SerializeField] private string _buildingDescription = default;
        
        public string BuildingName => _buildingName;
        public EBuildingType BuildingType => _buildingType;
        public string BuildingDescription => _buildingDescription;
    }
}
