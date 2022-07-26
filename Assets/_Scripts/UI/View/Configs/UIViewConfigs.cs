using UnityEngine;

namespace _Scripts.UI.Screen.Configs
{
    [CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]
    public class UIViewConfigs : ScriptableObject
    {
        private const string ASSET_FILE_NAME = nameof(UIViewConfigs);
        private const string ASSET_FILE_PATH = nameof(UI) + "/Data/" + ASSET_FILE_NAME;
        private const int ASSET_MENU_ORDER = int.MinValue + 1001;

        [SerializeField] private float m_showDuration = 0;
        [SerializeField] private float m_hideDuration = 0;

        public float ShowDuration => m_showDuration;
        public float HideDuration => m_hideDuration;
    }
}
