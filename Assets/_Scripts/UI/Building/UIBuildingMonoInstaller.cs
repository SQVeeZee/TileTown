using _Scripts.UI.Building;
using UnityEngine;
using Zenject;

namespace UI.Building
{
    public sealed class UIBuildingMonoInstaller : MonoInstaller
    {
        [SerializeField] private UIBuildingView m_view;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIBuildingViewModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIBuildingView>().FromInstance(m_view).AsSingle();
        }
    }
}