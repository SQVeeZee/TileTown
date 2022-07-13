using _Scripts.UI.Canvas;
using _Scripts.UI.View.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.UI
{
    public class UIMonoInstaller : MonoInstaller
    {
        [SerializeField] private UICanvas m_canvas = null;

        [Header("Configs")] 
        [SerializeField] private UIViewConfigs m_configs = null;

        public override void InstallBindings()
        {
            BindCanvas();

            BindConfigs();
        }

        private void BindConfigs()
        {
            Container.BindInstance(m_configs).AsSingle().NonLazy();
        }

        private void BindCanvas()
        {
            Container.BindInterfacesAndSelfTo<UICanvas>().FromInstance(m_canvas).AsSingle().NonLazy();
        }
    }
}