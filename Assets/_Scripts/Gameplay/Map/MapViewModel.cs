using System;
using _Scripts.Gameplay.Tile.Map.Selection;
using _Scripts.UI.Control;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map
{
    public interface IMap
    {
        public event Action<TileController> TileClicked;
        public void GenerateMap((int width, int height) gridSize);
    }
    
    public class MapViewModel: IMap, IInitializable, IDisposable
    {
        public event Action<TileController> TileClicked;
        
        private readonly MapModel m_model = null;
        private readonly ControlController m_controlController;

        private readonly MapClickModule m_mapClickModule = null;
        private readonly MapSelectionModule m_selectionModule = null;
        private readonly MapGenerationModule m_mapGenerationModule = null;

        [Inject]
        public MapViewModel(
            MapModel model,
            ControlController controlController,
            MapClickModule mapClickModule,
            MapSelectionModule selectionModule,
            MapGenerationModule mapGenerationModule
            )
        {
            m_model = model;
            
            m_controlController = controlController;
            
            m_mapClickModule = mapClickModule;
            m_selectionModule = selectionModule;
            m_mapGenerationModule = mapGenerationModule;
        }
        
        void IInitializable.Initialize()
        {
            m_controlController.Clicked += OnClicked;
        }

        void IDisposable.Dispose()
        {
            m_controlController.Clicked -= OnClicked;
        }


        void IMap.GenerateMap((int width, int height) gridSize)
        {
            var generateMap = m_mapGenerationModule.GenerateMap(gridSize);

            m_model.Tiles = generateMap;
        }

        private void OnClicked(Vector2 screenPosition)
        {
            var clickedTile = m_mapClickModule.GetTileByPosition(m_model.Tiles, screenPosition);

            if (clickedTile != null)
            {
                m_selectionModule.SelectTile(clickedTile);
                
                TileClicked?.Invoke(clickedTile);
            }
        }
    }
}
