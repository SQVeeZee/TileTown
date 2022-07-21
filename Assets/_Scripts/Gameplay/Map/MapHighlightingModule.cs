using System.Collections.Generic;
using JetBrains.Annotations;

namespace _Scripts.Gameplay.Tile.Map.Highlighting
{
    [UsedImplicitly]
    public class MapHighlightingModule
    {
        private List<TileController> m_highlightedTiles;

        private void HighlightFreeTiles(TileController[,] tiles)
        {
            m_highlightedTiles = new List<TileController>();

            foreach (var tile in tiles)
            {
                if (tile.GetTileState == ETileState.FILLED) return;

                m_highlightedTiles.Add(tile);

                tile.SetTileHighlightState(true);
            }
        }

        private void StopHighlight()
        {
            if (m_highlightedTiles.Count == 0) return;

            foreach (var tile in m_highlightedTiles)
            {
                tile.SetTileHighlightState(false);
            }

            m_highlightedTiles.Clear();
        }
    }
}