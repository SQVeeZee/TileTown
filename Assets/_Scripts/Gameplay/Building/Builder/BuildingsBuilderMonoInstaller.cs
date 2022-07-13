using _Scripts.Gameplay.Building.Builder.Configs;
using _Scripts.UI.Building;
using _Scripts.UI.Building.Builder;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building.Builder
{
    public class BuildingsBuilderMonoInstaller : MonoInstaller
    {
        [Header("Configs")] 
        [SerializeField] private BuildingsBuilderConfigs m_configs = null;

        [Header("View")] 
        [SerializeField] private UIBuildingsBuilderPanel m_view = null;
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
            Container.BindInterfacesAndSelfTo<UIBuildingsBuilderPanel>()
                .FromComponentInNewPrefab(m_view)
                .AsSingle().NonLazy();
        }

        private void BindViewModel()
        {
            Container.Bind<BuildingBuilderModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingsBuilderViewModel>().AsSingle().NonLazy();
        }
        
        private void BindFactory()
        {
            Container.BindFactory<UnityEngine.Object, Transform, BuildingViewModel, BuildingViewModel.Factory>()
                .FromFactory<PrefabFactory<Transform, BuildingViewModel>>();
            
            Container.BindFactory<UIBuildingViewModel, UIBuildingViewModel.Factory>()
                .FromComponentInNewPrefab(m_uiBuildingPrefab);
        }
    }
}

