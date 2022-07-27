using UnityEngine;

namespace _Scripts.UI.View.Configs
{
    [CreateAssetMenu(fileName = AssetFileName, menuName = AssetFilePath, order = AssetMenuOrder)]
    public class UIViewConfigs : ScriptableObject
    {
        private const string AssetFileName = nameof(UIViewConfigs);
        private const string AssetFilePath = nameof(UI) + "/Data/" + AssetFileName;
        private const int AssetMenuOrder = int.MinValue + 1001;

        [SerializeField] private float _showDuration = 0;
        [SerializeField] private float _hideDuration = 0;

        public float ShowDuration => _showDuration;
        public float HideDuration => _hideDuration;
    }
}
