using Gameplay.Building.Configs;
using JetBrains.Annotations;
using UI.Building.Impact.Impacts.Configs;
using UnityEngine;
using Zenject;

namespace Gameplay.Building
{
    public class BuildingViewModel: MonoBehaviour
    {
        [SerializeField] private Transform m_transform;
        
        private BuildingModel m_model = null;
        private BuildingView m_view = null;
        
        public BaseBuildingConfigs Configs => m_model.Configs;
        public BuildingImpactsConfigs ImpactConfigs => m_model.ImpactsConfigs;
        
        [Inject]
        public void Constructor(
            BuildingModel buildingModel,
            BuildingView buildingView
        )
        {
            m_model = buildingModel;
            m_view = buildingView;
        }

        public void Remove()
        {
            
        }

        private void SetPosition(Transform parent)
        {
            m_transform.SetParent(parent, false);
        }
        
        [UsedImplicitly]
        public class Factory : PlaceholderFactory<UnityEngine.Object, Transform, BuildingViewModel>
        {
            public override BuildingViewModel Create(UnityEngine.Object prefab, Transform parent)
            {
                var instance = base.Create(prefab, parent);

                instance.SetPosition(parent);
                
                return instance;
            }
        }
    }
}
