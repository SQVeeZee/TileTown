using System;
using System.Collections.Generic;
using _Scripts.Gameplay.Building.Impact.Move;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map
{
    public class MapHighlighting : IInitializable, IDisposable
    {
        private readonly MapController m_mapController = null;
        private readonly MapGenerationSystem m_mapGenerationSystem = null;
        private readonly MoveImpactViewModel m_moveImpact = null;
        
        private List<TileController> m_highlightedTiles;
        private TileController[,] m_map = null;
        
        [Inject]
        public MapHighlighting(
            MapGenerationSystem mapGenerationSystem,
            MoveImpactViewModel moveImpact
        )
        {
            m_mapGenerationSystem = mapGenerationSystem;
            
            m_moveImpact = moveImpact;
        }

        void IInitializable.Initialize()
        {
            m_mapGenerationSystem.MapGenerated += OnMapGenerated;

            m_moveImpact.ImpactActivated += OnImpactActivated;
            m_moveImpact.ImpactCompleted += OnImpactCompleted;
        }

        void IDisposable.Dispose()
        {
            m_mapGenerationSystem.MapGenerated -= OnMapGenerated;
            
            m_moveImpact.ImpactActivated -= OnImpactActivated;
            m_moveImpact.ImpactCompleted -= OnImpactCompleted;
        }
        
        private void OnMapGenerated(TileController[,] map)
        {
            m_map = map;
        }

        private void OnImpactActivated()
        {
            HighlightFreeTiles();
        }

        private void OnImpactCompleted()
        {
            StopHighlight();
        }

        private void HighlightFreeTiles()
        {
            m_highlightedTiles = new List<TileController>();

            foreach (var tileController in m_map)
            {
                m_highlightedTiles.Add(tileController);

                tileController.TryToHighlight();
            }
        }

        private void StopHighlight()
        {
            if (m_highlightedTiles.Count == 0) return;

            foreach (var highlightedTile in m_highlightedTiles)
            {
                highlightedTile.ChangeToDefaultColor();
            }

            m_highlightedTiles.Clear();
        }
    }
}
