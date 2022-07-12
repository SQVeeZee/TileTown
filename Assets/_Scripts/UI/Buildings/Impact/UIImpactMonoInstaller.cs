using UI.Building.Impact;
using UnityEngine;
using Zenject;

public class UIImpactMonoInstaller : MonoInstaller
{
    [SerializeField] private UIBuildingImpactView m_view;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<UIBuildingImpactModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<UIBuildingImpactViewModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<UIBuildingImpactView>().FromInstance(m_view).AsSingle();
    }
}
