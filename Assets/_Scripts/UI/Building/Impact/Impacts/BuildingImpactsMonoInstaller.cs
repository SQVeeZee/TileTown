using _Scripts.Gameplay.Building.Impact.Impacts;
using UnityEngine;
using Zenject;

namespace UI.Building.Impact.Impacts
{
    public sealed class BuildingImpactsMonoInstaller : MonoInstaller
    {
        [Header("Panels")]
        [SerializeField] private UIBuildingImpactsPanel m_impactsPanel = null;
        [SerializeField] private BuildingImpactViewModel m_impactPrefab = null;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ImpactsController>().AsSingle().NonLazy();
            
            BindImpacts();

            BindImpactFactory();
        }

        #region Impacts

        private void BindImpacts()
        {
            Container.Bind<BuildingImpactsModel>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BuildingImpactsViewModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UIBuildingImpactsPanel>().FromComponentInNewPrefab(m_impactsPanel)
                .AsSingle().NonLazy();
        }

        #endregion

        #region Impact

        private void BindImpactFactory()
        {
            Container.BindMemoryPool<BuildingImpactViewModel, BuildingImpactViewModel.Pool>()
                .FromComponentInNewPrefab(m_impactPrefab);
        }

        #endregion
    }
}