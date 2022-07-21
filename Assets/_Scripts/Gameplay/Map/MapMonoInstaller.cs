using _Scripts.Gameplay.Tile.Manipulation;
using _Scripts.Gameplay.Tile.Map.Grid;
using _Scripts.Gameplay.Tile.Map.Highlighting;
using _Scripts.Gameplay.Tile.Map.Selection;
using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Tile.Map
{
    public sealed class MapMonoInstaller : MonoInstaller
    {
        [SerializeField] private Transform m_parent = null;
        
        [Header("Prefab")]
        [SerializeField] private GameObject m_tileControllerPrefab = null;
        
        public override void InstallBindings()
        {
            BindMap();

            BindTileFactory();
        }

        private void BindMap()
        {
            Container.BindInterfacesAndSelfTo<MapViewModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MapModel>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<MapClickModule>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MapSelectionModule>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MapGenerationModule>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<GridMapGenerator>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<TileManipulationViewModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MapHighlightingModule>().AsSingle().NonLazy();
        }

        private void BindTileFactory()
        {
            Container.BindFactory<TileView, TileController.Factory>()
                .FromComponentInNewPrefab(m_tileControllerPrefab).UnderTransform(m_parent);
        }
    }
}