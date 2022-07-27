using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Gameplay.Building.Builder.Configs
{
    [CreateAssetMenu(fileName = AssetFileName, menuName = AssetFilePath, order = AssetMenuOrder)]

    public class BuildingsBuilderConfigs : ScriptableObject
    {
        private const string AssetFileName = nameof(BuildingsBuilderConfigs);
        private const string AssetFilePath = nameof(BuildingBuilderConfigs) + "/Data/" + AssetFileName;
        private const int AssetMenuOrder = int.MinValue + 1001;

        [SerializeField] private List<BuildingBuilderConfigs> _builderConfigs;

        public IReadOnlyList<BuildingBuilderConfigs> GroupBuilderConfigs => _builderConfigs;
    }
}