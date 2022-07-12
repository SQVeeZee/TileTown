using Gameplay.Building;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Gameplay.Tile
{
    public class TileController : MonoBehaviour
    {
        [SerializeField] private Transform m_tileTransform = null;
        
        private TileView m_view = null;
        private TileModel m_model = null;

        public Transform TileTransform => m_tileTransform;
        
        public Vector3 TilePosition { get; private set; } = default;
        
        public ETileState TileState { get; set; }
        public BuildingViewModel BuildingViewModel { get; set; } = null;
        
        private Vector3 m_tileSize = default;

        [Inject]
        public void Construct(
            TileView view,
            TileModel model
        )
        {
            m_view = view;
            m_model = model;
        }

        public void SetPosition(Vector3 position)
        {
            ReceiveTileStartSize();
            
            TilePosition = new Vector3(position.x, 0, position.y);
            
            m_view.ChangePosition(TilePosition);
        }

        public bool IsClickedTile(Vector3 clickPosition)
        {
            Vector2 clickedPoint = new Vector2(clickPosition.x, clickPosition.y);
            Vector2 tilePosition = new Vector2(TilePosition.x, TilePosition.z);
            
            if (Vector2.Distance(clickedPoint, tilePosition) < m_tileSize.x)
            {
                return true;
            }

            return false;
        }
        
        private void ReceiveTileStartSize()
        {
            m_tileSize = m_tileTransform.lossyScale / 2;
        }
        
        [UsedImplicitly]
        public class Factory : PlaceholderFactory<TileController> { }
    }
}
