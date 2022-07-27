using _Scripts.UI.Building.Builder;
using _Scripts.UI.Building.Impact;
using _Scripts.UI.Building.Impact.Impacts;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Impacts
{
    public sealed class UIBuildingImpactsMonoInstaller : MonoInstaller
    {
        [SerializeField] private Transform _parent = null;
        
        [Header("Impacts")]
        [SerializeField] private UIBuildingImpactsScreen _buildingImpactsScreen = null;
        [SerializeField] private UIBuildingImpactView _impactPrefab = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<IuiBuildingImpactsViewModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UIBuildingImpactsBuilder>().AsSingle().NonLazy();
            
            Container.Bind<UIBuildingImpactsScreen>().FromComponentInNewPrefab(_buildingImpactsScreen)
                .UnderTransform(_parent).AsSingle().NonLazy();
            
            Container.BindMemoryPool<UIBuildingImpactView, UIBuildingImpactView.Pool>()
                .FromComponentInNewPrefab(_impactPrefab);
        }
    }
}