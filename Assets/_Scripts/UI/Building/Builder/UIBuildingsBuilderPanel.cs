using UnityEngine;

namespace _Scripts.UI.Buildings.Builder
{
    public class UIBuildingsBuilderPanel : BaseUIView
    {
        [SerializeField] private Transform m_buildingsElementsRoot = null;

        public Transform GridRoot => m_buildingsElementsRoot;
    }
}
