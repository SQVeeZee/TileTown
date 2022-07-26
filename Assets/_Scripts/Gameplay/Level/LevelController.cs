using _Scripts.Gameplay.Level.Configs;
using _Scripts.Gameplay.Tile.Map.Grid;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Level
{
    public class LevelController: MonoBehaviour
    {
        [SerializeField] private Transform m_container = null;
        
        private LevelConfigs m_levelConfigs = null;
        private IMapGenerator m_mapGenerator = null;
        
        [Inject]
        public void Construct(
            LevelConfigs levelConfigs,
            IMapGenerator mapViewModel
            )
        {
            m_levelConfigs = levelConfigs;

            m_mapGenerator = mapViewModel;
        }
        
        private void Awake()
        {
            var gridSize = (m_levelConfigs.Width, m_levelConfigs.Height);
            
            m_mapGenerator.GenerateMap(gridSize, m_container);
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
