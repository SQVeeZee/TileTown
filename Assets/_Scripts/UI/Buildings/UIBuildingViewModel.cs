using System;
using Gameplay.Building.Configs;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

public class UIBuildingViewModel : MonoBehaviour
{
    public event Action<EBuildingType> BuildingClicked = null;

    [SerializeField] private RectTransform m_transform = null;
    
    private UIBuildingView m_view = null;
    
    private UIBuildingConfigs m_viewConfigs = null;
    private BaseBuildingConfigs m_buildingConfigs = null;
    
    [Inject]
    public void Constructor(
        UIBuildingView view
        )
    {
        m_view = view;
    }

    public void Initialize(
        BaseBuildingConfigs buildingConfigs,
        UIBuildingConfigs viewBuildingConfigs, 
        Transform parent)
    {
        m_viewConfigs = viewBuildingConfigs;
        m_buildingConfigs = buildingConfigs;

        m_view.Initialize(
            buildingConfigs.BuildingName,
            viewBuildingConfigs.IconColor
        );
        
        SetTransform(parent);

        m_view.ViewClicked += OnViewClicked;
    }

    private void OnViewClicked()
    {
        BuildingClicked?.Invoke(m_buildingConfigs.BuildingType);
    }

    private void SetTransform(Transform parent)
    {
        m_transform.SetParent(parent,false);
        
        m_transform.localScale = Vector3.one;
    }

    [UsedImplicitly]
    public class Factory : PlaceholderFactory< UIBuildingViewModel>
    {
    }
}
