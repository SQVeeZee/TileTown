using UnityEngine;

[CreateAssetMenu(fileName = ASSET_FILE_NAME, menuName = ASSET_FILE_PATH, order = ASSET_MENU_ORDER)]
public class TileViewConfigs : ScriptableObject
{
    private const string ASSET_FILE_NAME = nameof(TileViewConfigs);
    private const string ASSET_FILE_PATH = nameof(TileViewConfigs) + "/Configs/" + ASSET_FILE_NAME;
    private const int ASSET_MENU_ORDER = int.MinValue + 1001;

    [SerializeField] private Color m_interactiveColor = Color.white;

    public Color InteractiveColor => m_interactiveColor;
}
