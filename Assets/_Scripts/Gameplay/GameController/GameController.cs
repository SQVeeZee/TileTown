using Gameplay.Level;
using UnityEngine;
using Zenject;

namespace Gameplay.Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject m_levelControllerPrefab = null;
        [SerializeField] private Transform m_levelParent = null;
        
        private LevelController.Factory m_levelFactory = null;

        [Inject]
        public void Construct(
            LevelController.Factory levelFactory
        )
        {
            m_levelFactory = levelFactory;
        }

        private void Start()
        {
            InstanceLevel();
        }

        private void InstanceLevel()
        {
            m_levelFactory.Create(m_levelControllerPrefab, m_levelParent);
        }
    }
}

