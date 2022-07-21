using System;
using UnityEngine;

namespace _Scripts.Gameplay.Tile.Configs
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]
    public class TileViewConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(TileViewConfigs);
        private const string ASSET_FILE_PATH = nameof(TileViewConfigs) + "/Data/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;

        [SerializeField] private TileData m_tileData = null;

        public TileData TileData => m_tileData;
    }

    [Serializable]
    public class TileData
    {
        [SerializeField] private Color m_interactiveColor = Color.white;
        [SerializeField] private Color m_selectedColor = Color.white;

        public Color InteractiveColor => m_interactiveColor;
        public Color SelectedColor => m_selectedColor;
    }
}
