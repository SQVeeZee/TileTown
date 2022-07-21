using System;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building
{
    public class BuildingView : MonoBehaviour
    {
        public event Action<BuildingView> TileDestroyed = null;
        
        [SerializeField] private Transform m_transform = null;
        
        [SerializeField] protected SpriteRenderer m_sprite = null;
        [SerializeField] protected Transform m_impactPoint = null;

        public Transform ImpactPoint => m_impactPoint;
        
        public IBuilding Building { get; private set; }
        
        [Inject]
        public void Constructor(
            IBuilding building
            )
        {
            Building = building;
        }
        
        public void Remove()
        {
            TileDestroyed?.Invoke(this);
            
            Destroy(gameObject);
        }

        public void SetParent(Transform parent, bool positionStays = false)
        {
            m_transform.SetParent(parent, positionStays);
        }
    }
}