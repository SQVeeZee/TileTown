using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private Transform m_tileTransform = null;

    public Transform TailRoot => m_tileTransform;
}
