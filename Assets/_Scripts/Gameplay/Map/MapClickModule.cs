using Cameras;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map
{
    [UsedImplicitly]
    public class MapClickModule
    {
        private readonly CamerasController m_camerasController = null;

        private Camera m_uiCamera = null;
        
        [Inject]
        public MapClickModule(
            CamerasController camerasController
        )
        {
            m_camerasController = camerasController;
        }
        
        public TileController GetTileByPosition(TileController[,] tiles, Vector2 worldPosition)
        {
            if (TryGetTileByClick(tiles, worldPosition, out TileController tileController))
            {
                return tileController;
            }

            return null;
        }
        
        private bool TryGetTileByClick(TileController[,] tiles, Vector2 viewPoint, out TileController tile)
        {
            if (m_uiCamera == null)
            {
                m_uiCamera = m_camerasController.GetCamera(ECameraId.UI).Camera;
            }

            var worldPoint = m_uiCamera.ScreenToWorldPoint(viewPoint);

            if (TryGetTileByPosition(tiles, worldPoint, out TileController tileController))
            {
                tile = tileController;
                return true;
            }

            tile = null;
            return false;
        }
        
        private bool TryGetTileByPosition(TileController[,] tiles, Vector3 clickedPosition, out TileController tile)
        {
            tile = null;
            
            foreach (var tileController in tiles)
            {
                if (tileController.IsClickedTile(clickedPosition))
                {
                    tile = tileController;
                    return true;
                }
            }

            return false;
        }
    }
}
