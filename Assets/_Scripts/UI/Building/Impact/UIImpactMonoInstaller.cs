using _Scripts.UI.Building.Impact;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building.Impact
{
    public class UIImpactMonoInstaller : MonoInstaller
    {
        [SerializeField] private UIBuildingImpactView m_view;
        [SerializeField] private UIBuildingImpactViewModel m_impactViewModel = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIBuildingImpactModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIBuildingImpactView>().FromInstance(m_view).AsSingle();
        }
    }
}
