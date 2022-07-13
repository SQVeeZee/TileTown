using UnityEngine;
using Zenject;

namespace Gameplay.Tile
{
    public class TileModel
    {
        private readonly TileViewConfigs m_viewConfigs = null;
        
        public TileViewConfigs ViewConfigs => m_viewConfigs;
        public Color DefaultColor { get; set; }
        
        [Inject]
        public TileModel(
            TileViewConfigs viewConfigs
            )
        {
            m_viewConfigs = viewConfigs;
        }
    }
}