using JetBrains.Annotations;
using UI.Building.Impact.Configs;
using UnityEngine;
using Zenject;

namespace UI.Building.Impact
{
    public class UIBuildingImpactViewModel: MonoBehaviour, IPoolable<BuildingImpactConfigs, Transform>
    {
        public event System.Action<EBuildingImpactType> ImpactClicked = null;

        [SerializeField] private RectTransform m_transform = null;
        
        private UIBuildingImpactModel m_model = null;
        private UIBuildingImpactView m_view = null;
        
        [Inject]
        public void Construct(
            UIBuildingImpactView view,
            UIBuildingImpactModel model
            )
        {
            m_view = view;
            m_model = model;
        }
        
        public void OnDespawned()
        {
            m_view.ActionClicked -= OnActionClicked;
        }

        public void OnSpawned(BuildingImpactConfigs configs, Transform parent)
        {
            SetParent(parent);
            
            InitializeModel(configs);
            InitializeView(configs);

            m_view.ActionClicked += OnActionClicked;
        }
        
        private void SetParent(Transform parentTransform)
        {
            m_transform.SetParent(parentTransform);
        }

        private void InitializeModel(BuildingImpactConfigs configs)
        {
            m_model.Initialize(configs);
        }

        private void InitializeView(BuildingImpactConfigs configs)
        {
            m_view.Initialize(
                configs.ImpactName,
                configs.ImpactColor
                );
        }

        private void OnActionClicked()
        {
            ImpactClicked?.Invoke(m_model.ImpactType);
        }
        
        [UsedImplicitly]
        public class Pool : MonoPoolableMemoryPool<BuildingImpactConfigs, Transform, UIBuildingImpactViewModel>
        {
        }
    }
}
