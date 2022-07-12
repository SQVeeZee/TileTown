using UI.Building.Impact.Impacts.Configs;
using UnityEngine;
using Zenject;

public class BuildingImpactMonoInstaller : MonoInstaller
{
    [SerializeField] private BuildingImpactsConfigs m_configs;
    public override void InstallBindings()
    {
        Container.BindInstance(m_configs).AsSingle();
    }
}
