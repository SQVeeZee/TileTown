using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building
{
    public sealed class UIBuildingMonoInstaller : MonoInstaller
    {
        [SerializeField] private UIBuildingView _view;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UIBuildingView>().FromInstance(_view).AsSingle();
        }
    }
}