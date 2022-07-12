using Gameplay.Tile;
using UnityEngine;
using Zenject;

public class TestMonoInstaller : MonoInstaller
{
    [SerializeField] private GameObject m_tileControllerPrefab = null;

    public override void InstallBindings()
    {
        // Container.BindInterfacesAndSelfTo<TileController>().AsSingle().NonLazy();

        Container.BindFactory<TileController, TileController.Factory>()
            .FromComponentInNewPrefab(m_tileControllerPrefab);
    }
}