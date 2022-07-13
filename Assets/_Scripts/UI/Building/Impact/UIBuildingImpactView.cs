using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace UI.Building.Impact
{
    public class UIBuildingImpactView : MonoBehaviour
    {
        public event System.Action ImpactClicked = null;

        [SerializeField] private TextMeshProUGUI m_actionText = null;
        [SerializeField] private Image m_backgroundImage = null;

        [SerializeField] private Button m_actionButton = null;

        public void Initialize(
            string actionText,
            Color backgroundColor
            )
        {
            UpdateActionText(actionText);
            ChangeBackgroundColor(backgroundColor);

            AddListener(OnActionClicked);
        }

        private void AddListener(UnityAction action)
        {
            m_actionButton.onClick.AddListener(action);
        }

        private void OnActionClicked()
        {
            ImpactClicked?.Invoke();
        }

        private void ChangeBackgroundColor(Color backgroundColor)
        {
            m_backgroundImage.color = backgroundColor;
        }

        private void UpdateActionText(string text)
        {
            m_actionText.text = text;
        }
    }
}
