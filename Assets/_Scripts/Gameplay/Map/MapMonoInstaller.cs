using Gameplay.Map.Grid;
using Gameplay.Tile;
using UnityEngine;
using Zenject;

namespace Gameplay.Map
{
    public sealed class MapMonoInstaller : MonoInstaller
    {
        [SerializeField] private Transform m_parent = null;
        
        [SerializeField] private GameObject m_tileControllerPrefab = null;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MapGenerationSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GridMapGenerator>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<MapController>().AsSingle().NonLazy();

            Container.BindFactory<TileController, TileController.Factory>()
                .FromComponentInNewPrefab(m_tileControllerPrefab);
            
            
        }
    }
}