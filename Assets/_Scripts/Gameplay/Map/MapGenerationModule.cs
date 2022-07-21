using System;
using _Scripts.Gameplay.Tile.Map.Grid;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map
{
    public class MapGenerationModule
    {
        private readonly IMapGenerator m_mapGenerator = null;
        
        [Inject]
        public MapGenerationModule(
            IMapGenerator mapGenerator
            )
        {
            m_mapGenerator = mapGenerator;
        }

        public TileController[,] GenerateMap((int width, int height) size)
        {
            var map = m_mapGenerator.GenerateMap(size);

            return map;
        }
    }
}