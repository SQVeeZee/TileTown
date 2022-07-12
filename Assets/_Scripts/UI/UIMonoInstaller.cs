using UI.View.Configs;
using UnityEngine;
using Zenject;

public class UIMonoInstaller : MonoInstaller
{
    [Header("Configs")] 
    [SerializeField] private UIViewConfigs m_configs = null;
    
    public override void InstallBindings()
    {
        BindConfigs();
    }

    private void BindConfigs()
    {
        Container.BindInstance(m_configs).AsSingle().NonLazy();
    }
}
