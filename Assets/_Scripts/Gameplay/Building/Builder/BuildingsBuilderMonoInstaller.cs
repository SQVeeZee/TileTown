using _Scripts.Gameplay.Building.Builder.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building.Builder
{
    public class BuildingsBuilderMonoInstaller : MonoInstaller
    {
        [SerializeField] private BuildingsBuilderConfigs _configs = null;

        public override void InstallBindings()
        {
            BindBuildingBuilder();
        }

        private void BindBuildingBuilder()
        {
            Container.BindInstance(_configs).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<BuildingsBuilderModule>().AsSingle().NonLazy();

            Container.BindFactory<UnityEngine.Object, Transform, BuildingView, BuildingViewModel.Factory>()
                .FromFactory<PrefabFactory<Transform, BuildingView>>();
        }
    }
}

