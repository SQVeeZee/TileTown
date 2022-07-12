using UnityEngine;
using Zenject;

namespace Gameplay.Tile
{
    public sealed class TileMonoInstaller : MonoInstaller
    {
        [SerializeField] private TileView m_view;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TileController>().AsSingle();
            Container.BindInterfacesAndSelfTo<TileModel>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<TileView>().FromInstance(m_view).AsSingle();
        }
    }
}
