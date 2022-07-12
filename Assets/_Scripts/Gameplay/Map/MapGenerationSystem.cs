using System;
using Gameplay.Map.Grid;
using Gameplay.Tile;
using Zenject;

namespace Gameplay.Map
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