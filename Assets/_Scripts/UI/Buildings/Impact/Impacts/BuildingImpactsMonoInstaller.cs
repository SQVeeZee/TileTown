using UnityEngine;
using Zenject;

namespace UI.Building.Impact.Impacts
{
    public sealed class BuildingImpactsMonoInstaller : MonoInstaller
    {
        [SerializeField] private Transform m_parent = null;

        [Header("Panels")]
        [SerializeField] private UIBuildingImpactsPanel m_impactsPanel = null;
        [SerializeField] private UIBuildingImpactViewModel m_impactPrefab = null;
        
        public override void InstallBindings()
        {
            BindImpacts();

            BindImpactFactory();
        }

        #region Impacts

        private void BindImpacts()
        {
            Container.Bind<BuildingImpactsModel>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BuildingImpactsViewModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UIBuildingImpactsPanel>().FromComponentInNewPrefab(m_impactsPanel)
                .UnderTransform(m_parent)
                .AsSingle().NonLazy();
        }

        #endregion

        #region Impact

        private void BindImpactFactory()
        {
            Container.BindMemoryPool<UIBuildingImpactViewModel, UIBuildingImpactViewModel.Pool>()
                .FromComponentInNewPrefab(m_impactPrefab)
                .UnderTransform(m_parent);
        }

        #endregion
    }
}