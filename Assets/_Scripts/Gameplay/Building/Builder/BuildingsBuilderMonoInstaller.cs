using _Scripts.Gameplay.Building.Builder.Configs;
using _Scripts.UI.Building;
using _Scripts.UI.Building.Builder;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building.Builder
{
    public class BuildingsBuilderMonoInstaller : MonoInstaller
    {
        [Header("Data")] 
        [SerializeField] private BuildingsBuilderConfigs m_configs = null;

        [Header("View")] 
        [SerializeField] private UIBuildingsBuilderScreen m_view = null;
        [SerializeField] private GameObject m_uiBuildingPrefab = null;

        public override void InstallBindings()
        {
            BindConfigs();

            BindView();
            BindViewModel();
            
            BindFactory();
        }

        private void BindConfigs()
        {
            Container.BindInstance(m_configs).AsSingle().NonLazy();
        }

        private void BindView()
        {
            Container.BindInterfacesAndSelfTo<UIBuildingsBuilderScreen>()
                .FromComponentInNewPrefab(m_view)
                .AsSingle().NonLazy();
        }

        private void BindViewModel()
        {
            Container.Bind<BuildingBuilderModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingsBuilderModule>().AsSingle().NonLazy();
        }
        
        private void BindFactory()
        {
            Container.BindFactory<UnityEngine.Object, Transform, BuildingView, BuildingViewModel.Factory>()
                .FromFactory<PrefabFactory<Transform, BuildingView>>();
            
            Container.BindFactory<UIBuildingView, UIBuildingViewModel.Factory>()
                .FromComponentInNewPrefab(m_uiBuildingPrefab);
        }
    }
}

