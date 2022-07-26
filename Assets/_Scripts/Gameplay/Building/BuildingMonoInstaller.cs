using _Scripts.Gameplay.Building.Configs;
using _Scripts.Gameplay.Building.Impacts.Move;
using _Scripts.UI.Building.Impacts.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building
{
    public class BuildingMonoInstaller : MonoInstaller
    {
        [SerializeField] private BaseBuildingConfigs m_configs = null;
        [SerializeField] private BuildingImpactsConfigs m_impactsConfigs = null;
        [SerializeField] private BuildingView m_view = null;
        
        public override void InstallBindings()
        {
            BindModel();
        }

        private void BindModel()
        {
            Container.BindInstance(m_configs).AsSingle().NonLazy();
            Container.BindInstance(m_impactsConfigs).AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<BuildingViewModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingView>().FromInstance(m_view).AsSingle();

            Container.BindInterfacesAndSelfTo<BuildingMoveModule>().AsSingle().NonLazy();
        }
    }
}
