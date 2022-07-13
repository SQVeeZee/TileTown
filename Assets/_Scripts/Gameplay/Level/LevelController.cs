using _Scripts.Gameplay.Tile.Map;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Level
{
    public class LevelController: MonoBehaviour
    {
        private MapGenerationSystem m_mapGenerator = null;
        
        [Inject]
        public void Construct(
            MapGenerationSystem mapGenerator)
        {
            m_mapGenerator = mapGenerator;
        }
        
        private void Start()
        {
            m_mapGenerator.GenerateMap();
        }

        private void SetParent(Transform parent)
        {
            transform.SetParent(parent, true);
        }
        
        
        [UsedImplicitly]
        public class Factory : PlaceholderFactory<UnityEngine.Object, Transform, LevelController>
        {
            public override LevelController Create(UnityEngine.Object prefab, Transform parent)
            {
                var instance = base.Create(prefab, parent);

                instance.SetParent(parent);
                
                return instance;
            }
        }
    }
}
