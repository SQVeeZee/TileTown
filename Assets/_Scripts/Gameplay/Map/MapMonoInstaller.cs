using _Scripts.Gameplay.Tile.Map.Grid;
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
            Container.BindInterfacesAndSelfTo<MapGenerationSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GridMapGenerator>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MapController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MapModel>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<MapHighlighting>().AsSingle().NonLazy();
        }

        private void BindTileFactory()
        {
            Container.BindFactory<TileController, TileController.Factory>()
                .FromComponentInNewPrefab(m_tileControllerPrefab).UnderTransform(m_parent);
        }
    }
}