using _Scripts.Gameplay.Level.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Level
{
    public class LevelMonoInstaller : MonoInstaller
    {
        [SerializeField] private LevelConfigs m_levelConfigs = null;

        public override void InstallBindings()
        {
            Container.BindInstance(m_levelConfigs).AsSingle();
            // Container.BindInterfacesAndSelfTo<LevelController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LevelModel>().AsSingle().NonLazy();
        }
    }
}