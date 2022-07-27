using System;
using _Scripts.Gameplay.Building.Configs;
using _Scripts.Gameplay.Building.Impacts.Info;
using _Scripts.UI.Screen;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI.Building.Info
{
    public class UIBuildingInfoScreen : BaseScreen
    {
        [Header("Text")] 
        [SerializeField] private TextMeshProUGUI _nameText = null;
        [SerializeField] private TextMeshProUGUI _typeText = null;
        [SerializeField] private TextMeshProUGUI _description = null;

        [Header("Button")] 
        [SerializeField] private Button _closeButton = null;

        private IInfoImpactModule _infoImpactModule = null;
        private IDisposable _disposableConfigs = null;

        [Inject]
        public void Constructor(
            IInfoImpactModule infoImpactModule
            )
        {
            _infoImpactModule = infoImpactModule;
        }

        public override void Initialize()
        {
            _disposableConfigs = _infoImpactModule.BuildingConfigs.Where(x => x != null)
                .Subscribe(OnConfigsUpdated);
            
            AddListenerToCloseButton(OnCloseButtonPressed);
        }

        public override void Dispose()
        {
            _disposableConfigs.Dispose();
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
            _closeButton.onClick.AddListener(action);
        }

        private void OnCloseButtonPressed()
        {
            _infoImpactModule.ResetImpact();
            
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
            UpdateText(_nameText, buildingName);
            UpdateText(_typeText, buildingType);
            UpdateText(_description, buildingDescription);
        }
    }
}