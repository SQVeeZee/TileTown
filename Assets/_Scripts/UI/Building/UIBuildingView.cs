using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIBuildingView : MonoBehaviour
{
    public event Action ViewClicked = null;
    
    [SerializeField] private Button m_Button = null;
    [SerializeField] private TextMeshProUGUI m_nameText = null;
    [SerializeField] private Image m_iconImage = null;
    
    public void Initialize(string nameText, Color iconColor)
    {
        UpdateIconColor(iconColor);
        ChangeName(nameText);
        
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
        ViewClicked?.Invoke();
    }
    
    private void UpdateNameText(string nameText)
    {
        m_nameText.text = nameText;
    }

    private void UpdateIconColor(Color targetColor)
    {
        m_iconImage.color = targetColor;
    }
}
