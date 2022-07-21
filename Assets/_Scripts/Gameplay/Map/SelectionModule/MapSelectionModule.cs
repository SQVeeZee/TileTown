using System;
using JetBrains.Annotations;

namespace _Scripts.Gameplay.Tile.Map.Selection
{
    [UsedImplicitly]
    public class MapSelectionModule
    {
        public event Action<ISelectable, ISelectable> UpdateSelectedTile = null;
        
        private ISelectable m_selectedTile = null;
        private ISelectable m_previousSelectedTile = null;

        public ISelectable SelectedTile
        {
            get => m_selectedTile;
            private set => m_selectedTile = value;
        }

        public void SelectTile(ISelectable tile)
        {
            if (tile == m_selectedTile) return;

            UnSelect();
            
            m_selectedTile = tile;
            m_selectedTile.Select();
            
            UpdateSelectedTile?.Invoke(m_previousSelectedTile, m_selectedTile);
        }

        private void UnSelect()
        {
            if (m_selectedTile == null) return;
            
            m_selectedTile.UnSelect();
            m_previousSelectedTile = m_selectedTile;
        }
    }
}