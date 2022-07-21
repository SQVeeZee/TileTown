using System;
using _Scripts.Gameplay.Building;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile
{
    public interface ISelectable
    {
        public event Action<bool> SelectStateChanged;
        void Select();
        void UnSelect();
    }
    
    [UsedImplicitly]
    public class TileController: ISelectable
    {
        public event Action<bool> TileHighlightStateChanged = null;
        public event Action<bool> SelectStateChanged;

        public Color InteractiveColor => m_model.TileData.InteractiveColor;
        public Color SelectedColor => m_model.TileData.SelectedColor;
        public Transform TileTransform => m_model.TileTransform;
        
        public ETileState GetTileState => m_model.TileState;
        
        private TileModel m_model = null;

        [Inject]
        public void Construct(
            TileModel model
        )
        {
            m_model = model;
        }

        public void Initialize(
            Transform tileTransform,
            Vector3 tileSize
            )
        {
            m_model.TileTransform = tileTransform;
            m_model.TileSize = tileSize;
        }

        public void SetTilePosition(Vector3 position)
        {
            m_model.Position = position;
        }
        
        public void SetTileBuilding(BuildingViewModel building)
        {
            if (building == null) return;
            
            m_model.BuildingViewModel = building;
            m_model.TileState = ETileState.FILLED;
        }

        public void SetTileHighlightState(bool state)
        {
            TileHighlightStateChanged?.Invoke(state);
        }

        public bool IsClickedTile(Vector3 clickPosition)
        {
            var position = m_model.Position;
            var tileSize = m_model.TileSize;
            
            Vector2 clickedPoint = new Vector2(clickPosition.x, clickPosition.y);
            Vector2 tilePosition = new Vector2(position.x, position.z);
            
            if (Vector2.Distance(clickedPoint, tilePosition) < tileSize.x)
            {
                return true;
            }

            return false;
        }

        void ISelectable.Select()
        {
            SelectStateChanged?.Invoke(true);
        }

        void ISelectable.UnSelect()
        {
            SelectStateChanged?.Invoke(false);
        }
        
        private void ResetBuilding()
        {
            m_model.TileState = ETileState.EMPTY;
            m_model.BuildingViewModel = null;
        }
        
        [UsedImplicitly]
        public class Factory : PlaceholderFactory<TileView> { }
    }
}
