using System;
using _Scripts.Gameplay.Tile.Map.Grid;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map
{
    public class MapGenerationSystem
    {
        public event Action<TileController[,]> MapGenerated = null;
        
        private readonly IMapGenerator m_mapGenerator = null;
        
        [Inject]
        public MapGenerationSystem(
            IMapGenerator mapGenerator
            )
        {
            m_mapGenerator = mapGenerator;
        }

        public void GenerateMap((int width, int height) size)
        {
            var map = m_mapGenerator.GenerateMap(size);

            MapGenerated?.Invoke(map);
        }
    }
}