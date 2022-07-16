using System;
using _Scripts.Gameplay.Building.Impact;
using _Scripts.UI.Building.Impact.Configs;
using _Scripts.UI.Canvas;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Impact
{
    public class UIBuildingImpactViewModel: MonoBehaviour, IPoolable<BuildingImpactConfigs, Transform>
    {
        public event Action<EImpactType> ImpactClicked = null;
        
        [SerializeField] private RectTransform m_transform = null;
        
        private UIBuildingImpactModel m_model = null;
        private UIBuildingImpactView m_view = null;

        private UICanvas m_canvas = null;

        [Inject]
        public void Construct(
            UIBuildingImpactView view,
            UIBuildingImpactModel model,
            UICanvas canvas
            )
        {
            m_view = view;
            m_model = model;

            m_canvas = canvas;
        }
        
        public void OnDespawned()
        {
            SetParent(m_canvas.ViewParent);

            m_view.ImpactClicked -= OnImpactClicked;
        }

        public void OnSpawned(BuildingImpactConfigs configs, Transform parent)
        {
            SetParent(parent);
            
            InitializeModel(configs);
            InitializeView(configs);

            m_view.ImpactClicked += OnImpactClicked;
        }
        
        private void SetParent(Transform parentTransform)
        {
            m_transform.SetParent(parentTransform, false);
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

        private void OnImpactClicked()
        {
            ImpactClicked?.Invoke(m_model.ImpactType);
        }
        
        [UsedImplicitly]
        public class Pool : MonoPoolableMemoryPool<BuildingImpactConfigs, Transform, UIBuildingImpactViewModel>
        {
        }
    }
}
