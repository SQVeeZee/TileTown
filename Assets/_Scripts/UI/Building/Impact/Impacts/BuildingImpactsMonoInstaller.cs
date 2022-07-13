using _Scripts.UI.Building.Impact;
using _Scripts.UI.Building.Impact.Impacts;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building.Impact.Impacts
{
    public sealed class BuildingImpactsMonoInstaller : MonoInstaller
    {
        [Header("Panels")]
        [SerializeField] private UIBuildingImpactsPanel m_impactsPanel = null;
        [SerializeField] private UIBuildingImpactViewModel m_impactPrefab = null;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ImpactsController>().AsSingle().NonLazy();
            
            BindImpacts();

            BindImpactFactory();
        }

        private void BindImpacts()
        {
            Container.Bind<BuildingImpactsModel>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BuildingImpactsViewModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UIBuildingImpactsPanel>().FromComponentInNewPrefab(m_impactsPanel)
                .AsSingle().NonLazy();
        }

        private void BindImpactFactory()
        {
            Container.BindMemoryPool<UIBuildingImpactViewModel, UIBuildingImpactViewModel.Pool>()
                .FromComponentInNewPrefab(m_impactPrefab);
        }
    }
}