using _Scripts.Gameplay.Level.Configs;
using _Scripts.Gameplay.Tile.Map.Grid;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Level
{
    public class LevelController: MonoBehaviour
    {
        [SerializeField] private Transform _container = null;
        
        private LevelConfigs _levelConfigs = null;
        private IMapGenerator _mapGenerator = null;
        
        [Inject]
        public void Construct(
            LevelConfigs levelConfigs,
            IMapGenerator mapViewModel
            )
        {
            _levelConfigs = levelConfigs;

            _mapGenerator = mapViewModel;
        }
        
        private void Awake()
        {
            var gridSize = (_levelConfigs.Width, _levelConfigs.Height);
            
            _mapGenerator.GenerateMap(gridSize, _container);
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
