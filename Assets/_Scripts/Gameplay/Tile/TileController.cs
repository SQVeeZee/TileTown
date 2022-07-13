using _Scripts.Gameplay.Building;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile
{
    public class TileController : MonoBehaviour
    {
        [SerializeField] private Transform m_tileTransform = null;
        
        private TileView m_view = null;
        private TileModel m_model = null;

        public Transform TileTransform => m_tileTransform;

        public ETileState TileState { get; private set; } = ETileState.EMPTY;
        
        public BuildingViewModel BuildingViewModel { get; private set; } = null;
        
        private Vector3 m_tileSize = default;
        private Vector3 m_position = default;

        [Inject]
        public void Construct(
            TileView view,
            TileModel model
        )
        {
            m_view = view;
            m_model = model;
        }

        private void Start()
        {
            m_model.DefaultColor = m_view.SpriteColor;
        }

        public void SetPosition(Vector3 position)
        {
            ReceiveTileStartSize();
            
            m_position = new Vector3(position.x, 0, position.y);
            
            m_view.ChangePosition(m_position);
        }

        public void SetTileBuilding(BuildingViewModel building)
        {
            if (building == null) return;
            
            BuildingViewModel = building;
            TileState = ETileState.FILLED;
                
            BuildingViewModel.TileMove += ResetBuilding;
            BuildingViewModel.TileRemove += ResetBuilding;
        }

        private void ResetBuilding()
        {
            BuildingViewModel.TileMove -= ResetBuilding;
            BuildingViewModel.TileRemove -= ResetBuilding;
            
            TileState = ETileState.EMPTY;
            BuildingViewModel = null;
        }

        public bool IsClickedTile(Vector3 clickPosition)
        {
            Vector2 clickedPoint = new Vector2(clickPosition.x, clickPosition.y);
            Vector2 tilePosition = new Vector2(m_position.x, m_position.z);
            
            if (Vector2.Distance(clickedPoint, tilePosition) < m_tileSize.x)
            {
                return true;
            }

            return false;
        }

        public void TryToHighlight()
        {
            if (IsFreeTile())
            {
                ChangeToInteractiveColor();
            }
        }

        private bool IsFreeTile()
        {
            if (TileState == ETileState.EMPTY) 
                return true;

            return false;
        }

        private void ChangeToInteractiveColor()
        {
            m_view.ChangeColor(m_model.ViewConfigs.InteractiveColor);
        }

        public void ChangeToDefaultColor()
        {
            m_view.ChangeColor(m_model.DefaultColor);
        }
        
        private void ReceiveTileStartSize()
        {
            m_tileSize = m_tileTransform.lossyScale / 2;
        }
        
        [UsedImplicitly]
        public class Factory : PlaceholderFactory<TileController> { }
    }
}
