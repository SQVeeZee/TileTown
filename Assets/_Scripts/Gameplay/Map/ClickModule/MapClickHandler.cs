using System;
using _Scripts.Gameplay.Tile.Map.Grid;
using _Scripts.UI.Control;
using Cameras;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map.Click
{
    public interface IMapClickHandler
    {
        public event Action<ITileViewModel> TileClicked;
    }
    
    [UsedImplicitly]
    public class MapClickHandler: IMapClickHandler, IInitializable, IDisposable
    {
        public event Action<ITileViewModel> TileClicked;

        private readonly IMapGenerator m_mapViewModel = null;

        private readonly CamerasController m_camerasController = null;
        private readonly ControlController m_controlController;
        
        private Camera m_uiCamera = null;
        private ITileViewModel[,] m_tiles = null;
        
        [Inject]
        public MapClickHandler(
            IMapGenerator map,
            CamerasController camerasController,
            ControlController controlController
        )
        {
            m_mapViewModel = map;

            m_camerasController = camerasController;
            m_controlController = controlController;
        }
        
        void IInitializable.Initialize()
        {
            m_mapViewModel.MapGenerated += OnMapGenerated;
            m_controlController.Clicked += OnClicked;
        }

        void IDisposable.Dispose()
        {
            m_mapViewModel.MapGenerated -= OnMapGenerated;
            m_controlController.Clicked -= OnClicked;
        }

        private void OnMapGenerated(ITileViewModel[,] tiles)
        {
            m_tiles = tiles;
        }
        
        private void OnClicked(Vector2 screenPosition)
        {
            if (m_tiles.Length == 0) return;
            
            var clickedTile = GetTile(m_tiles, screenPosition);

            if (clickedTile == null) return;
            
            TileClicked?.Invoke(clickedTile);
        }
        
        private ITileViewModel GetTile(ITileViewModel[,] tiles, Vector2 worldPosition)
        {
            if (TryGetTileByClick(tiles, worldPosition, out ITileViewModel clickedTile))
            {
                return clickedTile;
            }

            return null;
        }
        
        private bool TryGetTileByClick(ITileViewModel[,] tiles, Vector2 viewPoint, out ITileViewModel tile)
        {
            var worldPoint = ConvertScreenToWorldPosition(viewPoint);
            
            if (TryGetTileByPosition(tiles, worldPoint, out ITileViewModel tileController))
            {
                tile = tileController;
                return true;
            }

            tile = null;
            return false;
        }

        private Vector3 ConvertScreenToWorldPosition(Vector2 screenPosition)
        {
            if (m_uiCamera == null)
            {
                m_uiCamera = m_camerasController.GetCamera(ECameraId.UI).Camera;
            }

            var worldPoint = m_uiCamera.ScreenToWorldPoint(screenPosition);

            return worldPoint;
        }
        
        private bool TryGetTileByPosition(ITileViewModel[,] tiles, Vector3 clickedPosition, out ITileViewModel tile)
        {
            tile = null;
            
            foreach (var tileController in tiles)
            {
                if (IsClickedTile(tileController, clickedPosition))
                {
                    tile = tileController;
                    return true;
                }
            }

            return false;
        }
        
        private bool IsClickedTile(ITileViewModel tile, Vector3 clickPosition)
        {
            var position = tile.Position;
            var tileSize = tile.Size;
            
            Vector2 clickedPoint = new Vector2(clickPosition.x, clickPosition.y);
            Vector2 tilePosition = new Vector2(position.x, position.z);
            
            if (Vector2.Distance(clickedPoint, tilePosition) < tileSize.x)
            {
                return true;
            }

            return false;
        }
    }
}
