using System;
using UnityEngine;

namespace _Scripts.Gameplay.Building.Configs
{
    [CreateAssetMenu(fileName = AssetFileName, menuName = AssetFilePath, order = AssetMenuOrder)]
    public class UIBuildingConfigs : ScriptableObject
    {
        private const string AssetFileName = nameof(UIBuildingConfigs);
        private const string AssetFilePath = nameof(UIBuildingsConfigs) + "/" + AssetFileName;
        private const int AssetMenuOrder = int.MinValue + 1001;

        [SerializeField] private UIBuildingIconData _buildingIconData = null;
        
        public UIBuildingIconData BuildingIconData => _buildingIconData;
    }

    [Serializable]
    public class UIBuildingIconData
    {
        [SerializeField] private BaseBuildingConfigs _baseBuildingConfigs = null;
        [SerializeField] private Color _color = Color.white;
        
        public BaseBuildingConfigs BaseBuildingConfigs => _baseBuildingConfigs;
        public Color IconColor => _color;
    }
}
