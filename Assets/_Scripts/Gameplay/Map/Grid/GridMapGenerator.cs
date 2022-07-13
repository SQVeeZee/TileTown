using System;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map.Grid
{
    public class GridMapGenerator : IMapGenerator
    {
        public event Action<TileController[,]> MapGenerated = null;
        
        private readonly TileController.Factory m_tileFactory = null;

        private int m_width = 5;
        private int m_height = 4;
        
        [Inject]
        public GridMapGenerator(
            TileController.Factory tileFactory
        )
        {
            m_tileFactory = tileFactory;
        }
        
        TileController[,] IMapGenerator.GenerateMap()
        {
            return GenerateMap();
        }

        private TileController[,] GenerateMap()
        {
            TileController[,] map = new TileController[m_width, m_height];
            
            for (int i = 0; i < m_width; i++)
            {
                for (int j = 0; j < m_height; j++)
                {
                    Vector2 tilePosition = new Vector2(i, j); 
                    
                    var controller = m_tileFactory.Create();
                    controller.SetPosition(tilePosition);

                    map[i, j] = controller;
                }   
            }

            MapGenerated?.Invoke(map);
            
            return map;
        }
    }
}