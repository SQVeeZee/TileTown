using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] private Transform m_canvasTransform = null;

    public Transform ViewParent => m_canvasTransform;
}
