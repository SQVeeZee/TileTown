using _Scripts.Gameplay.Building.Impacts.Info;
using _Scripts.Gameplay.Building.Impacts.Move;
using _Scripts.Gameplay.Building.Impacts.Remove;
using _Scripts.Gameplay.Tile.Map.Selection;
using Zenject;

namespace _Scripts.Gameplay.Building.Impacts
{
    public class ImpactsMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ImpactsManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MapSelectionModule>().AsSingle().NonLazy();
            
            BindReMoveImpact();
            BindMoveImpact();
            BindInfoImpact();
        }

        private void BindReMoveImpact()
        {
            Container.BindInterfacesAndSelfTo<RemoveImpactModule>().AsSingle().NonLazy();
        }

        private void BindMoveImpact()
        {
            Container.BindInterfacesAndSelfTo<MoveImpactViewModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MoveImpactModule>().AsSingle().NonLazy();
        }

        private void BindInfoImpact()
        {
            Container.BindInterfacesAndSelfTo<InfoImpactModule>().AsSingle().NonLazy();
        }
    }
}
