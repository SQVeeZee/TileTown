using UnityEngine;
using Zenject;

namespace Cameras
{
    public class CameraMonoInstaller : MonoInstaller
    {
        [SerializeField]
        private CameraView m_view = null;
        
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CameraController>().FromNew().AsSingle().NonLazy();
            Container.BindInstance(m_view).AsSingle().NonLazy();
        }
    }
}