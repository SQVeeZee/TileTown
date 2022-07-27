using _Scripts.Gameplay.Building.Configs;
using _Scripts.Gameplay.Building.Impact.Configs;
using _Scripts.Gameplay.Building.Module;
using _Scripts.UI.Building.Impacts.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building
{
    public class BuildingMonoInstaller : MonoInstaller
    {
        [SerializeField] private BaseBuildingConfigs _configs = null;
        [SerializeField] private BuildingImpactsConfigs _impactsConfigs = null;
        [SerializeField] private BuildingView _view = null;
        
        public override void InstallBindings()
        {
            BindModel();
        }

        private void BindModel()
        {
            Container.BindInstance(_configs).AsSingle().NonLazy();
            Container.BindInstance(_impactsConfigs).AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<BuildingViewModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuildingView>().FromInstance(_view).AsSingle();

            Container.BindInterfacesAndSelfTo<BuildingMoveModule>().AsSingle().NonLazy();
        }
    }
}
