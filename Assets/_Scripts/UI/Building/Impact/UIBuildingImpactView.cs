using System;
using _Scripts.UI.Building.Impacts.Configs;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI.Building.Impact
{
    public class UIBuildingImpactView : MonoBehaviour, IUIBuildingImpact
    {
        public event Action<EImpactType> ImpactClicked;

        [SerializeField] private Transform _transform = null;
        
        [SerializeField] private TextMeshProUGUI _text = null;
        [SerializeField] private Image _backgroundImage = null;
        [SerializeField] private Button _button = null;

        private EImpactType _buildingType = EImpactType.None;

        public void OnSpawned(BuildingImpactConfigs configs, Transform parent)
        {
            _buildingType = configs.BuildImpactType;
            
            UpdateActionText(configs.ImpactName);
            ChangeBackgroundColor(configs.ImpactColor);

            AddListener();

            SetRootTransform(parent);
        }
        
        public void OnDespawned()
        {
            RemoveListener();
            SetRootTransform(null);
        }

        private void AddListener()
        {
            _button.onClick.AddListener(OnImpactClicked);
        }
        
        private void RemoveListener()
        {
            _button.onClick.AddListener(OnImpactClicked);
        }

        private void OnImpactClicked()
        {
            ImpactClicked?.Invoke(_buildingType);
        }

        private void ChangeBackgroundColor(Color backgroundColor)
        {
            _backgroundImage.color = backgroundColor;
        }

        private void UpdateActionText(string text)
        {
            _text.text = text;
        }
        
        private void SetRootTransform(Transform parent)
        {
            _transform.SetParent(parent, false);
        }
        
        [UsedImplicitly]
        public class Pool : MonoPoolableMemoryPool<BuildingImpactConfigs, Transform, UIBuildingImpactView>
        {
            
        }
    }
}
