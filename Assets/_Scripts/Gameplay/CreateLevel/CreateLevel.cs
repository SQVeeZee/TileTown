using Gameplay.Level.Item;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

[UsedImplicitly]
public class CreateLevel: MonoBehaviour
{
    [SerializeField] private GameObject m_levelControllerPrefab = null;

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
        m_levelFactory.Create(m_levelControllerPrefab, transform);
    }
}
