using _Scripts.Gameplay.Tile.Map.Grid;
using _Scripts.Gameplay.Tile.Map.Highlighting;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map
{
    public sealed class MapMonoInstaller : MonoInstaller
    {
        [Header("Prefab")]
        [SerializeField] private TileView _tileControllerPrefab = null;
        
        public override void InstallBindings()
        {
            BindMap();

            BindTileFactory();
        }

        private void BindMap()
        {
            Container.BindInterfacesAndSelfTo<MapViewModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GridMapGenerator>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<MapHighlightingModule>().AsSingle().NonLazy();
        }

        private void BindTileFactory()
        {
            Container.BindMemoryPool<TileView, TileView.Pool>()
                .FromComponentInNewPrefab(_tileControllerPrefab);
        }
    }
}