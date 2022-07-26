using System;
using UnityEngine;

namespace _Scripts.Gameplay.Tile.Map.Grid
{
    public interface IMapGenerator
    {
        event Action<ITileViewModel[,]> MapGenerated;
        public ITileViewModel[,] GenerateMap((int width, int height) size, Transform parent);
    }
}