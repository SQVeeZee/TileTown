using System;
using _Scripts.Gameplay.Building.Configs;
using _Scripts.UI.Screen;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Gameplay.Building.Impacts.Info
{
    public class UIBuildingInfoScreen : BaseScreen
    {
        [Header("Text")] 
        [SerializeField] private TextMeshProUGUI m_nameText = null;
        [SerializeField] private TextMeshProUGUI m_typeText = null;
        [SerializeField] private TextMeshProUGUI m_description = null;

        [Header("Button")] 
        [SerializeField] private Button m_closeButton = null;

        private IInfoImpactModule m_infoImpactModule = null;
        private IDisposable m_disposableConfigs = null;

        [Inject]
        public void Constructor(
            IInfoImpactModule infoImpactModule
            )
        {
            m_infoImpactModule = infoImpactModule;
        }

        public override void Initialize()
        {
            m_disposableConfigs = m_infoImpactModule.BuildingConfigs.Where(x => x != null)
                .Subscribe(OnConfigsUpdated);
            
            AddListenerToCloseButton(OnCloseButtonPressed);
        }

        public override void Dispose()
        {
            m_disposableConfigs.Dispose();
        }
        
        private void OnConfigsUpdated(BaseBuildingData buildingData)
        {
            SetInfo(buildingData);
        }
        
        private void SetInfo(BaseBuildingData buildingData)
        {
            var data = buildingData;
            
            SetInfo(
                data.BuildingName,
                data.BuildingType.ToString(),
                data.BuildingDescription);
        }

        private void AddListenerToCloseButton(UnityAction action)
        {
            m_closeButton.onClick.AddListener(action);
        }

        private void OnCloseButtonPressed()
        {
            m_infoImpactModule.ResetImpact();
            
            IsReadyToHide.Value = true;
        }

        private void UpdateText(TextMeshProUGUI tmp, string text)
        {
            tmp.text = text;
        }
        
        private void SetInfo(
            string buildingName,
            string buildingType,
            string buildingDescription
        )
        {
            UpdateText(m_nameText, buildingName);
            UpdateText(m_typeText, buildingType);
            UpdateText(m_description, buildingDescription);
        }
    }
}