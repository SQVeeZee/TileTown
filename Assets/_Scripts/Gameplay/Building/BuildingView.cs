using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building
{
    public class BuildingView : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer m_sprite = null;
        [SerializeField] protected Transform m_impactPoint = null;

        public Transform ImpactPoint => m_impactPoint;
            
        [UsedImplicitly]
        public class Factory : PlaceholderFactory<UnityEngine.Object, Transform, BuildingView>
        {
            public override BuildingView Create(Object prefab, Transform parent)
            {
                var instance = base.Create(prefab, parent);

                return instance;
            }
        }
    }
}
