using System;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map.Grid
{
    public class GridMapGenerator : IMapGenerator
    {
        public event Action<ITileViewModel[,]> MapGenerated = null;
        
        private readonly TileView.Pool m_tilePool = null;

        [Inject]
        public GridMapGenerator(
            TileView.Pool tilePool
        )
        {
            m_tilePool = tilePool;
        }
        
        ITileViewModel[,] IMapGenerator.GenerateMap((int width, int height) size, Transform parent)
        {
            return GenerateMap(size, parent);
        }

        private ITileViewModel[,] GenerateMap((int width, int height) size, Transform parent)
        {
            int width = size.width;
            int height = size.height;
            
            ITileViewModel[,] map = new ITileViewModel[width, height];
            
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Vector3 tilePosition = new Vector3(i,0, j); 
                    
                    var tileView = m_tilePool.Spawn(tilePosition, parent);
                    tileView.gameObject.name = $"Tile {i}:{j}";
                    
                    map[i, j] = tileView.TileViewModel;
                }   
            }

            MapGenerated?.Invoke(map);
            
            return map;
        }
    }
}