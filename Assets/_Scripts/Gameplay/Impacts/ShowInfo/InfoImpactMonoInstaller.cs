using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building.Impact.Info
{
    public sealed class InfoImpactMonoInstaller : MonoInstaller
    {
        [SerializeField] private UIBuildingInfoPanel m_buildingInfoPanel = null;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InfoImpactViewModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UIBuildingInfoPanel>().FromComponentInNewPrefab(m_buildingInfoPanel)
                .AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<InfoImpactModel>().AsSingle().NonLazy();
        }
    }
}
