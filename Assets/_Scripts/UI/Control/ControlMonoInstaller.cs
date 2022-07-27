using _Scripts.Gameplay.Tile.Map.Click;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Control
{
    public sealed class ControlMonoInstaller : MonoInstaller
    {
        [SerializeField]
        private RectTransform _parent = null;
        
        [Header("Panel")]
        [SerializeField]
        private UIControlPanel _controlPanelPrefab = null;
        
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ControlController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ClickModeListener>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<MapClickHandler>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<UIControlPanel>().FromComponentInNewPrefab(_controlPanelPrefab)
                .UnderTransform(_parent)
                .AsSingle().NonLazy();
        }
    }
}