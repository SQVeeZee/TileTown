using Zenject;

namespace _Scripts.Gameplay.Building.Impact.Move
{
    public sealed class MoveImpactMonoInstaller : MonoInstaller
    {
        // [SerializeField] private MoveImpactView m_view = null;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MoveImpactViewModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MoveImpactModel>().AsSingle().NonLazy();
            // Container.BindInstance(m_view).AsSingle();
        }
    }
}