using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Gameplay.Building
{
    public class BuildingView : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer m_sprite = null;
        
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
