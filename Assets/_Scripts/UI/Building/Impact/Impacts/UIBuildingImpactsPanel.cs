using UnityEngine;

namespace UI.Building.Impact.Impacts
{
    public class UIBuildingImpactsPanel : BaseUIView
    {
        [SerializeField] private Transform m_impactParent = null;

        public Transform ImpactParent => m_impactParent;
    }
}