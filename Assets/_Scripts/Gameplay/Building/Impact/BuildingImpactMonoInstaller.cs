using _Scripts.UI.Building.Impact.Impacts.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Building.Impact
{
    public class BuildingImpactMonoInstaller : MonoInstaller
    {
        [SerializeField] private BuildingImpactsConfigs m_configs;

        public override void InstallBindings()
        {
            Container.BindInstance(m_configs).AsSingle();
        }
    }
}