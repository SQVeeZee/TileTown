using _Scripts.Gameplay.Tile.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile
{
    public sealed class TileMonoInstaller : MonoInstaller
    {
        [Header("View")] 
        [SerializeField] private TileViewConfigs m_viewConfigs = null;
        [SerializeField] private TileView m_view;
        
        public override void InstallBindings()
        {
            Container.BindInstance(m_viewConfigs).AsSingle();
            
            Container.BindInterfacesAndSelfTo<TileController>().AsSingle();
            Container.BindInterfacesAndSelfTo<TileModel>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<TileView>().FromInstance(m_view).AsSingle();
        }
    }
}
