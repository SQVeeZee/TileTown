using _Scripts.Gameplay.Tile.Configs;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile
{
    public sealed class TileMonoInstaller : MonoInstaller
    {
        [Header("View")] 
        [SerializeField] private TileViewConfigs _viewConfigs = null;
        [SerializeField] private TileView _view;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_viewConfigs).AsSingle();
            
            Container.BindInterfacesAndSelfTo<TileViewModel>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<TileView>().FromInstance(_view).AsSingle();
        }
    }
}
