using _Scripts.Gameplay.Tile.Map;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Level
{
    public class LevelController: MonoBehaviour
    {
        private IMap m_mapViewModel = null;
        private LevelModel m_model = null;
        
        [Inject]
        public void Construct(
            LevelModel model,
            IMap mapViewModel
            )
        {
            m_mapViewModel = mapViewModel;

            m_model = model;
        }
        
        private void Start()
        {
            (int width, int height) gridSize = (m_model.Width, m_model.Height);
            
            m_mapViewModel.GenerateMap(gridSize);
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
