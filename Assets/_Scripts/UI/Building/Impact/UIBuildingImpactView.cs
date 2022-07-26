using System;
using _Scripts.Gameplay.Building.Impacts;
using _Scripts.UI.Building.Impacts.Configs;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI.Building.Impacts
{
    public interface IUIBuildingImpact: IPoolable<BuildingImpactConfigs, Transform>
    {
        event Action<EImpactType> ImpactClicked;
    }
    
    public class UIBuildingImpactView : MonoBehaviour, IUIBuildingImpact
    {
        public event Action<EImpactType> ImpactClicked;

        [SerializeField] private Transform m_transform = null;
        
        [SerializeField] private TextMeshProUGUI m_actionText = null;
        [SerializeField] private Image m_backgroundImage = null;
        [SerializeField] private Button m_button = null;

        private EImpactType m_buildingType = EImpactType.NONE;

        public void OnSpawned(BuildingImpactConfigs configs, Transform parent)
        {
            m_buildingType = configs.BuildImpactType;
            
            
            UpdateActionText(configs.ImpactName);
            ChangeBackgroundColor(configs.ImpactColor);

            AddListener();

            SetRootTransform(parent);
        }
        
        public void OnDespawned()
        {
            RemoveListener();
        }

        private void AddListener()
        {
            m_button.onClick.AddListener(OnImpactClicked);
        }
        
        private void RemoveListener()
        {
            m_button.onClick.AddListener(OnImpactClicked);
        }

        private void OnImpactClicked()
        {
            ImpactClicked?.Invoke(m_buildingType);
        }

        private void ChangeBackgroundColor(Color backgroundColor)
        {
            m_backgroundImage.color = backgroundColor;
        }

        private void UpdateActionText(string text)
        {
            m_actionText.text = text;
        }
        
        private void SetRootTransform(Transform parent)
        {
            m_transform.SetParent(parent, false);
        }
        
        [UsedImplicitly]
        public class Pool : MonoPoolableMemoryPool<BuildingImpactConfigs, Transform, UIBuildingImpactView>
        {
            
        }
    }
}
