using UnityEngine;

namespace _Scripts.Gameplay.Level.Configs
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]
    public class LevelConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(LevelConfigs);
        private const string ASSET_FILE_PATH = nameof(_Scripts) + "/Data/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;


        [Header("GridSize")] [SerializeField] private int m_width = 0;
        [SerializeField] private int m_height = 0;

        public int Width => m_width;
        public int Height => m_height;
    }
}