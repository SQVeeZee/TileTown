using System.Collections.Generic;
using _Scripts.UI.Building.Impacts.Configs;
using UnityEngine;

namespace _Scripts.Gameplay.Building.Impact.Configs
{
    [CreateAssetMenu(fileName = AssetFileName, menuName = AssetFilePath, order = AssetMenuOrder)]
    public class BuildingImpactsConfigs : ScriptableObject
    {
        private const string AssetFileName = nameof(BuildingImpactsConfigs);
        private const string AssetFilePath = nameof(BuildingImpactsConfigs) + "/Data/" + AssetFileName;
        private const int AssetMenuOrder = int.MinValue + 1001;
        
        [SerializeField] private List<BuildingImpactConfigs> _impactConfigs = new List<BuildingImpactConfigs>();

        public IReadOnlyList<BuildingImpactConfigs> ImpactConfigs => _impactConfigs;
    }
}