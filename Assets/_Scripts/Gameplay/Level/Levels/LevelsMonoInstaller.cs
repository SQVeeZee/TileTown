using UnityEngine;
using Zenject;

namespace _Scripts.Gameplay.Level.Levels
{
    public class LevelsMonoInstaller : MonoInstaller
    {
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
}
