using _Scripts.UI.Building.Impacts.Builder;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Impacts
{
    public sealed class UIBuildingImpactsMonoInstaller : MonoInstaller
    {
        [SerializeField] private Transform m_parent = null;
        
        [Header("Impacts")]
        [SerializeField] private UIBuildingImpactsScreen m_buildingImpactsScreen = null;
        [SerializeField] private UIBuildingImpactView m_impactPrefab = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIBuildingImpactsViewModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UIBuildingImpactsBuilder>().AsSingle().NonLazy();
            
            Container.Bind<UIBuildingImpactsScreen>().FromComponentInNewPrefab(m_buildingImpactsScreen)
                .UnderTransform(m_parent).AsSingle().NonLazy();
            
            Container.BindMemoryPool<UIBuildingImpactView, UIBuildingImpactView.Pool>()
                .FromComponentInNewPrefab(m_impactPrefab);
        }
    }
}