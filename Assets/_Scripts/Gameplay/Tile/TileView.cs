using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile
{
    public class TileView : MonoBehaviour
    {
        [SerializeField] private Transform m_tileTransform = null;
        [SerializeField] private Transform m_hudPoint = null;

        [Header("View")] 
        [SerializeField] private SpriteRenderer m_sprite = null;

        public Transform HudPoint => m_hudPoint;

        public TileController TileController { get; private set; }
        
        private Color m_defaultColor = Color.white;
        
        [Inject]
        public void Constructor(
            TileController controller)
        {
            TileController = controller;

            m_defaultColor = m_sprite.color;

            TileController.TileHighlightStateChanged += OnHighlightingChanged;
            TileController.SelectStateChanged += OnSelectStateChanged;
                
            BindController();
        }

        private void BindController()
        {
            var tileSize = m_tileTransform.lossyScale / 2;
            
            TileController.Initialize(m_tileTransform, tileSize);
        }
        
        private void OnSelectStateChanged(bool state)
        {
            m_sprite.color = state ? TileController.SelectedColor : m_defaultColor;
        }

        private void OnHighlightingChanged(bool state)
        {
            m_sprite.color = state ? TileController.InteractiveColor : m_defaultColor;
        }
        
        public void SetPosition(Vector3 targetPosition)
        {
            targetPosition = new Vector3(targetPosition.x, 0, targetPosition.y);

            TileController.SetTilePosition(targetPosition);

            m_tileTransform.position = targetPosition;
        }
    }
}