using UnityEngine;

public class TileView : MonoBehaviour
{
    [SerializeField] private Transform m_tileTransform = null;
    [SerializeField] private Transform m_hudPoint = null;

    [Header("View")]
    [SerializeField] private SpriteRenderer m_sprite = null;
    
    public Transform HudPoint => m_hudPoint;
    public Color SpriteColor => m_sprite.color;
    
    public void ChangePosition(Transform parent, Vector2 position)
    {
        m_tileTransform.SetParent(parent);
        
        m_tileTransform.position = position;
    }
    
    public void ChangePosition(Vector3 position)
    {
        m_tileTransform.position = position;
    }

    public void ChangeColor(Color targetColor)
    {
        m_sprite.color = targetColor;
    }
}
