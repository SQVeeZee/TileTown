using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Tile.Map.Grid;
using JetBrains.Annotations;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map.Highlighting
{
    [UsedImplicitly]
    public class MapHighlightingModule : IHighlightingModule, IInitializable, IDisposable
    {
        private readonly IMapGenerator _generator = null;

        private List<ITileViewModel> _highlightedTiles;
        private ITileViewModel[,] _tiles;

        [Inject]
        public MapHighlightingModule(
            IMapGenerator mapGenerator
        )
        {
            _generator = mapGenerator;
        }

        void IInitializable.Initialize()
        {
            _generator.MapGenerated += OnMapGenerated;
        }

        void IDisposable.Dispose()
        {
            _generator.MapGenerated -= OnMapGenerated;
        }

        private void OnMapGenerated(ITileViewModel[,] tiles)
        {
            _tiles = tiles;
        }

        void IHighlightingModule.HighlightFreeTiles()
        {
            _highlightedTiles = new List<ITileViewModel>();

            foreach (var tile in _tiles)
            {
                if (!tile.IsEmpty) continue;

                _highlightedTiles.Add(tile);

                tile.SetTileHighlightState(true);
            }
        }

        void IHighlightingModule.ResetHighlighting()
        {
            if (_highlightedTiles.Count == 0) return;

            foreach (var tile in _highlightedTiles)
            {
                tile.SetTileHighlightState(false);
            }

            _highlightedTiles.Clear();
        }
    }
}