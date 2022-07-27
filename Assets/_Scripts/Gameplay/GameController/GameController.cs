using _Scripts.Gameplay.Level;
using UnityEngine;
using Zenject;

namespace Gameplay.Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject _levelControllerPrefab = null;
        [SerializeField] private Transform _levelParent = null;
        
        private LevelController.Factory _levelFactory = null;

        [Inject]
        public void Construct(
            LevelController.Factory levelFactory
        )
        {
            _levelFactory = levelFactory;
        }

        private void Start()
        {
            InstanceLevel();
        }

        private void InstanceLevel()
        {
            _levelFactory.Create(_levelControllerPrefab, _levelParent);
        }
    }
}

