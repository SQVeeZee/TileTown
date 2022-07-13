using System;
using _Scripts.Gameplay.Tile.Map.Grid;
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

        public void GenerateMap()
        {
            var map = m_mapGenerator.GenerateMap();

            MapGenerated?.Invoke(map);
        }
    }
}