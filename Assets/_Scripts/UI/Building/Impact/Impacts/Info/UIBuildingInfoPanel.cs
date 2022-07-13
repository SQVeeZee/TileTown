using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Building.Impact.Info
{
    public class UIBuildingInfoPanel : BaseUIView
    {
        public event Action CloseButtonPressed = null;

        [Header("Text")] 
        [SerializeField] private TextMeshProUGUI m_nameText = null;
        [SerializeField] private TextMeshProUGUI m_typeText = null;
        [SerializeField] private TextMeshProUGUI m_description = null;

        [Header("Button")] 
        [SerializeField] private Button b_closeButton = null;

        public void Initialize(
            string buildingName,
            string buildingType,
            string buildingDescription
        )
        {
            UpdateText(m_nameText, buildingName);
            UpdateText(m_typeText, buildingType);
            UpdateText(m_description, buildingDescription);

            this.Initialize();
        }

        private void Initialize()
        {
            AddListenerToCloseButton(OnCloseButtonPressed);
        }

        private void AddListenerToCloseButton(UnityAction action)
        {
            b_closeButton.onClick.AddListener(action);
        }

        private void OnCloseButtonPressed()
        {
            CloseButtonPressed?.Invoke();
        }

        private void UpdateText(TextMeshProUGUI tmp, string text)
        {
            tmp.text = text;
        }
    }
}