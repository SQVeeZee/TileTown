using System;
using _Scripts.Cameras;
using _Scripts.Gameplay.Tile.Map.Grid;
using _Scripts.UI.Control;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map.Click
{
    [UsedImplicitly]
    public class MapClickHandler: IMapClickHandler, IInitializable, IDisposable
    {
        public event Action<ITileViewModel> TileClicked;

        private readonly IMapGenerator _mapViewModel = null;

        private readonly CamerasController _camerasController = null;
        private readonly ControlController _controlController;
        
        private Camera _uiCamera = null;
        private ITileViewModel[,] _tiles = null;
        
        [Inject]
        public MapClickHandler(
            IMapGenerator map,
            CamerasController camerasController,
            ControlController controlController
        )
        {
            _mapViewModel = map;

            _camerasController = camerasController;
            _controlController = controlController;
        }
        
        void IInitializable.Initialize()
        {
            _mapViewModel.MapGenerated += OnMapGenerated;
            _controlController.Clicked += OnClicked;
        }

        void IDisposable.Dispose()
        {
            _mapViewModel.MapGenerated -= OnMapGenerated;
            _controlController.Clicked -= OnClicked;
        }

        private void OnMapGenerated(ITileViewModel[,] tiles)
        {
            _tiles = tiles;
        }
        
        private void OnClicked(Vector2 screenPosition)
        {
            if (_tiles.Length == 0) return;
            
            var clickedTile = GetTile(_tiles, screenPosition);

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
            if (_uiCamera == null)
            {
                _uiCamera = _camerasController.GetCamera(ECameraId.UI).Camera;
            }

            var worldPoint = _uiCamera.ScreenToWorldPoint(screenPosition);

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
