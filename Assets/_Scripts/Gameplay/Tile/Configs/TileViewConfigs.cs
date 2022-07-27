using System;
using UnityEngine;

namespace _Scripts.Gameplay.Tile.Configs
{
    [CreateAssetMenu(fileName = AssetFileName, menuName = AssetFilePath, order = AssetMenuOrder)]
    public class TileViewConfigs : ScriptableObject
    {
        private const string AssetFileName = nameof(TileViewConfigs);
        private const string AssetFilePath = nameof(TileViewConfigs) + "/Data/" + AssetFileName;
        private const int AssetMenuOrder = int.MinValue + 1001;

        [SerializeField] private TileData _tileData = null;

        public TileData TileData => _tileData;
    }

    [Serializable]
    public class TileData
    {
        [SerializeField] private Color _interactiveColor = Color.white;
        [SerializeField] private Color _selectedColor = Color.white;

        public Color InteractiveColor => _interactiveColor;
        public Color SelectedColor => _selectedColor;
    }
}
