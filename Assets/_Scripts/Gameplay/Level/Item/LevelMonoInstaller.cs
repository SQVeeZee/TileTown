using UnityEngine;
using Zenject;

namespace Gameplay.Level
{
    public sealed class LevelMonoInstaller : MonoInstaller
    {
        [SerializeField] private LevelView m_levelView = null;

        public override void InstallBindings()
        {
            Container.BindInstance(m_levelView).AsSingle();
        }
    }
}
