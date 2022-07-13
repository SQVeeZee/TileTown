namespace _Scripts.Gameplay.Tile.Map.Grid
{
    public interface IMapGenerator
    {
        public TileController[,] GenerateMap();
    }
}