using _Scripts.Gameplay.Building.Impacts.Info;
using _Scripts.UI.Building;
using _Scripts.UI.Building.Builder;
using _Scripts.UI.Building.Configs;
using _Scripts.UI.Screen.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Screens
{
    public sealed class UIMonoInstaller : MonoInstaller
    {
        [SerializeField] private Transform m_parentTransform = null;

        [Header("Data")] 
        [SerializeField] private UIViewConfigs m_configs = null;

        [Header("Screens")] 
        [Header("Builder")]
        [SerializeField] private UIBuildingsBuilderScreen m_buildingsBuilderScreen = null;
        [SerializeField] private UIBuildingsConfigs m_uiBuildingsConfigs = null;
        [SerializeField] private GameObject m_uiBuildingPrefab = null;
        
        [Header("Info")]
        [SerializeField] private UIBuildingInfoScreen m_buildingInfoScreen = null;

        public override void InstallBindings()
        {
            BindUI();
        }

        private void BindUI()
        {
            Container.BindInterfacesAndSelfTo<UIManager>().AsSingle().NonLazy();
            Container.BindInstance(m_configs).AsSingle().NonLazy();

            BindUIBuilder();
            
            BindInfo();
        }

        private void BindUIBuilder()
        {
            Container.BindInstance(m_uiBuildingsConfigs).AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<UIBuildingsBuilderModule>().AsSingle().NonLazy();
            
            Container.Bind<UIBuildingsBuilderScreen>().FromComponentInNewPrefab(m_buildingsBuilderScreen)
                .UnderTransform(m_parentTransform).AsSingle().NonLazy();
            
            Container.BindFactory<UIBuildingView, UIBuildingView.Factory>()
                .FromComponentInNewPrefab(m_uiBuildingPrefab);
        }

        private void BindInfo()
        {
            Container.Bind<UIBuildingInfoScreen>().FromComponentInNewPrefab(m_buildingInfoScreen)
                .UnderTransform(m_parentTransform).AsSingle().NonLazy();
        }
    }
}