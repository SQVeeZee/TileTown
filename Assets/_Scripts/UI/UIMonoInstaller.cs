using _Scripts.Gameplay.Building.Configs;
using _Scripts.UI.Building;
using _Scripts.UI.Building.Builder;
using _Scripts.UI.Building.Info;
using _Scripts.UI.Screens;
using _Scripts.UI.View.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.UI
{
    public sealed class UIMonoInstaller : MonoInstaller
    {
        [SerializeField] private Transform _parentTransform = null;

        [Header("Data")] 
        [SerializeField] private UIViewConfigs _viewConfigs = null;

        [Header("Screens")] 
        [Header("Builder")]
        [SerializeField] private UIBuildingsBuilderScreen _buildingsBuilderScreen = null;
        [SerializeField] private UIBuildingsConfigs _buildingsConfigs = null;
        [SerializeField] private GameObject _viewBuildingPrefab = null;
        
        [Header("Info")]
        [SerializeField] private UIBuildingInfoScreen _buildingInfoScreen = null;

        public override void InstallBindings()
        {
            BindUI();
        }

        private void BindUI()
        {
            Container.BindInterfacesAndSelfTo<UIManager>().AsSingle().NonLazy();
            Container.BindInstance(_viewConfigs).AsSingle().NonLazy();

            BindUIBuilder();
            
            BindInfo();
        }

        private void BindUIBuilder()
        {
            Container.BindInstance(_buildingsConfigs).AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<IuiBuildingsBuilderModule>().AsSingle().NonLazy();
            
            Container.Bind<UIBuildingsBuilderScreen>().FromComponentInNewPrefab(_buildingsBuilderScreen)
                .UnderTransform(_parentTransform).AsSingle().NonLazy();
            
            Container.BindFactory<UIBuildingView, UIBuildingView.Factory>()
                .FromComponentInNewPrefab(_viewBuildingPrefab);
        }

        private void BindInfo()
        {
            Container.Bind<UIBuildingInfoScreen>().FromComponentInNewPrefab(_buildingInfoScreen)
                .UnderTransform(_parentTransform).AsSingle().NonLazy();
        }
    }
}