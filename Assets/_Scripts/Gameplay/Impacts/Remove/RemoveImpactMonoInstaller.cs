using Zenject;

namespace _Scripts.Gameplay.Building.Impact.Remove
{
    public sealed class RemoveImpactMonoInstaller : MonoInstaller
    {
        // [SerializeField] private RemoveImpactView m_view;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RemoveImpactViewModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<RemoveImpactModel>().AsSingle().NonLazy();
            // Container.BindInstance(m_view).AsSingle();
        }
    }
}