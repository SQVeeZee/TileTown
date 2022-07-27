using _Scripts.Gameplay.Building.Impact.Configs;
using _Scripts.Gameplay.Building.Impacts;
using _Scripts.UI.Building.Impact;
using _Scripts.UI.Building.Impacts.Configs;
using UnityEngine;

namespace _Scripts.UI.Building.Impacts.Configs
{
    [CreateAssetMenu(fileName = AssetFileName, menuName = AssetFilePath, order = AssetMenuOrder)]
    public class BuildingImpactConfigs : ScriptableObject
    {
        private const string AssetFileName = nameof(BuildingImpactConfigs);
        private const string AssetFilePath = nameof(BuildingImpactsConfigs) + "/Data/" + AssetFileName;
        private const int AssetMenuOrder = int.MinValue + 1001;

        [SerializeField] private EImpactType _buildImpactType = EImpactType.None;
        [SerializeField] private Color _color = Color.white;
        [SerializeField] private string _impactName = default;
        
        public EImpactType BuildImpactType => _buildImpactType;
        public Color ImpactColor => _color;
        public string ImpactName => _impactName;
    }
}
