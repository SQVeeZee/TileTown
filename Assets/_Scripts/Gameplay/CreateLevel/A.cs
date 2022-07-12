using Gameplay.Tile;
using UnityEngine;
using Zenject;

public class A : MonoBehaviour
{
    private TileController.Factory m_factory;

    [Inject]
    public void Construct(
        TileController.Factory factory)
    {
        m_factory = factory;
    }

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            m_factory.Create();
            Debug.Log("!");
        }
    }
}