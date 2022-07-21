using _Scripts.Gameplay.Building;
using _Scripts.Gameplay.Tile.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile
{
    public class TileModel
    {
        public ETileState TileState { get; set; } = ETileState.EMPTY;
        public TileData TileData { get; } = null;
        public BuildingViewModel BuildingViewModel { get; set; } = null;
        
        public Vector3 TileSize { get; set; } = default;
        public Vector3 Position { get; set; } = default;
        public Transform TileTransform = null;
        
        [Inject]
        public TileModel(
            TileViewConfigs viewConfigs
            )
        {
            TileData = viewConfigs.TileData;
        }
    }
}