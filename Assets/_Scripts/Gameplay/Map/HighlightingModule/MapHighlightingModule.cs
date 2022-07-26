using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Tile.Map.Grid;
using JetBrains.Annotations;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map.Highlighting
{
    public interface IHighlightingModule
    {
        void HighlightFreeTiles();
        void ResetHighlighting();
    }

    [UsedImplicitly]
    public class MapHighlightingModule : IHighlightingModule, IInitializable, IDisposable
    {
        private readonly IMapGenerator m_generator = null;

        private List<ITileViewModel> m_highlightedTiles;
        private ITileViewModel[,] m_tiles;

        [Inject]
        public MapHighlightingModule(
            IMapGenerator mapGenerator
        )
        {
            m_generator = mapGenerator;
        }

        void IInitializable.Initialize()
        {
            m_generator.MapGenerated += OnMapGenerated;
        }

        void IDisposable.Dispose()
        {
            m_generator.MapGenerated -= OnMapGenerated;
        }

        private void OnMapGenerated(ITileViewModel[,] tiles)
        {
            m_tiles = tiles;
        }

        void IHighlightingModule.HighlightFreeTiles()
        {
            m_highlightedTiles = new List<ITileViewModel>();

            foreach (var tile in m_tiles)
            {
                if (!tile.IsEmpty) continue;

                m_highlightedTiles.Add(tile);

                tile.SetTileHighlightState(true);
            }
        }

        void IHighlightingModule.ResetHighlighting()
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