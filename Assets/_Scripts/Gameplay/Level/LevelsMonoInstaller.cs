using Gameplay.Level.Item;
using UnityEngine;
using Zenject;

public class LevelsMonoInstaller : MonoInstaller
{
    [SerializeField] private Transform m_rootTransform = null;
    
    public override void InstallBindings()
    {
        BindFactory();
    }
    
    private void BindFactory()
    {
        Container.BindFactory<UnityEngine.Object, Transform, LevelController, LevelController.Factory>()
            .FromFactory<PrefabFactory<Transform, LevelController>>();
    }
}
