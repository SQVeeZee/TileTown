using UnityEngine;
using Zenject;

namespace _Scripts.Cameras
{
    public class CameraMonoInstaller : MonoInstaller
    {
        [SerializeField]
        private CameraView _view = null;
        
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CameraController>().FromNew().AsSingle().NonLazy();
            Container.BindInstance(_view).AsSingle().NonLazy();
        }
    }
}