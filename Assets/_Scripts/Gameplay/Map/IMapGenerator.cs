using Gameplay.Tile;

namespace Gameplay.Map.Grid
{
    public interface IMapGenerator
    {
        public TileController[,] GenerateMap();
    }
}