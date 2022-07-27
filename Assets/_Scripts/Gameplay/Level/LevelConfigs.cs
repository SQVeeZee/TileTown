using UnityEngine;

namespace _Scripts.Gameplay.Level.Configs
{
    [CreateAssetMenu(fileName = AssetFileName, menuName = AssetFilePath, order = AssetMenuOrder)]
    public class LevelConfigs : ScriptableObject
    {
        private const string AssetFileName = nameof(LevelConfigs);
        private const string AssetFilePath = nameof(_Scripts) + "/Data/" + AssetFileName;
        private const int AssetMenuOrder = int.MinValue + 1001;


        [Header("GridSize")] 
        [SerializeField] private int _width = 0;
        [SerializeField] private int _height = 0;

        public int Width => _width;
        public int Height => _height;
    }
}