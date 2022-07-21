using System;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map.Grid
{
    public class GridMapGenerator : IMapGenerator
    {
        public event Action<TileController[,]> MapGenerated = null;
        
        private readonly TileController.Factory m_tileFactory = null;

        [Inject]
        public GridMapGenerator(
            TileController.Factory tileFactory
        )
        {
            m_tileFactory = tileFactory;
        }
        
        TileController[,] IMapGenerator.GenerateMap((int width, int height) size)
        {
            return GenerateMap(size);
        }

        private TileController[,] GenerateMap((int width, int height) size)
        {
            int width = size.width;
            int height = size.height;
            
            TileController[,] map = new TileController[width, height];
            
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Vector2 tilePosition = new Vector2(i, j); 
                    
                    var tileView = m_tileFactory.Create();
                    tileView.SetPosition(tilePosition);

                    map[i, j] = tileView.TileController;
                }   
            }

            MapGenerated?.Invoke(map);
            
            return map;
        }
    }
}