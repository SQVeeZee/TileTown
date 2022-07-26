using System;
using _Scripts.Gameplay.Building;
using _Scripts.UI.Building.Configs;
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

        [SerializeField] private Transform m_transform = null;
        
        [SerializeField] private Button m_Button = null;
        [SerializeField] private TextMeshProUGUI m_nameText = null;
        [SerializeField] private Image m_iconImage = null;

        private EBuildingType m_buildingType = EBuildingType.NONE;
        
        public void Initialize(UIBuildingConfigs buildingConfigs)
        {
            var baseBuildingConfigs = buildingConfigs.BuildingIconData;
            var buildingData = baseBuildingConfigs.BaseBuildingConfigs.BuildingData;

            var buildingType = buildingData.BuildingType;
            var text = buildingData.BuildingName;
            var iconColor = baseBuildingConfigs.IconColor;
            
            ChangeName(text);
            UpdateIconColor(iconColor);
            
            m_buildingType = buildingType;
            AddListener();
        }

        private void AddListener()
        {
            m_Button.onClick.AddListener(OnButtonClicked);
        }

        private void ChangeName(string nameText)
        {
            UpdateNameText(nameText);
        }

        private void OnButtonClicked()
        {
            ViewClicked?.Invoke(m_buildingType);
        }

        private void UpdateNameText(string nameText)
        {
            m_nameText.text = nameText;
        }

        private void UpdateIconColor(Color targetColor)
        {
            m_iconImage.color = targetColor;
        }
        
        public void SetTransform(Transform parent)
        {
            m_transform.SetParent(parent, false);

            m_transform.localScale = Vector3.one;
        }
        
        [UsedImplicitly]
        public class Factory : PlaceholderFactory<UIBuildingView>
        { }
    }
}