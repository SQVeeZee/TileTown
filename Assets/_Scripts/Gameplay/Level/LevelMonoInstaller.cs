using _Scripts.Gameplay.Level.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Level
{
    public class LevelMonoInstaller : MonoInstaller
    {
        [SerializeField] private LevelConfigs _levelConfigs = null;

        public override void InstallBindings()
        {
            Container.BindInstance(_levelConfigs).AsSingle();
        }
    }
}