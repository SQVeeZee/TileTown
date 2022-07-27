using System;
using _Scripts.Gameplay.Building;
using _Scripts.Gameplay.Building.Configs;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI.Building
{
    public class UIBuildingView : MonoBehaviour
    {
        public event Action<EBuildingType> ViewClicked = null;

        [SerializeField] private Transform _transform = null;
        
        [SerializeField] private Button _button = null;
        [SerializeField] private TextMeshProUGUI _nameText = null;
        [SerializeField] private Image _iconImage = null;

        private EBuildingType _buildingType = EBuildingType.None;
        
        public void Initialize(UIBuildingConfigs buildingConfigs)
        {
            var baseBuildingConfigs = buildingConfigs.BuildingIconData;
            var buildingData = baseBuildingConfigs.BaseBuildingConfigs.BuildingData;

            var buildingType = buildingData.BuildingType;
            var text = buildingData.BuildingName;
            var iconColor = baseBuildingConfigs.IconColor;
            
            ChangeName(text);
            UpdateIconColor(iconColor);
            
            _buildingType = buildingType;
            AddListener();
        }

        private void AddListener()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void ChangeName(string nameText)
        {
            UpdateNameText(nameText);
        }

        private void OnButtonClicked()
        {
            ViewClicked?.Invoke(_buildingType);
        }

        private void UpdateNameText(string nameText)
        {
            _nameText.text = nameText;
        }

        private void UpdateIconColor(Color targetColor)
        {
            _iconImage.color = targetColor;
        }
        
        public void SetTransform(Transform parent)
        {
            _transform.SetParent(parent, false);

            _transform.localScale = Vector3.one;
        }
        
        [UsedImplicitly]
        public class Factory : PlaceholderFactory<UIBuildingView>
        { }
    }
}