using Zenject;

namespace _Scripts.Cameras
{
    public class CamerasMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CamerasController>().FromNew().AsSingle().NonLazy();
            Container.Bind<CamerasContainer>().FromNew().AsSingle().NonLazy();
        }
    }
}