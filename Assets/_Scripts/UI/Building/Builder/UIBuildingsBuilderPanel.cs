using _Scripts.UI.View;
using UnityEngine;

namespace _Scripts.UI.Building.Builder
{
    public class UIBuildingsBuilderPanel : BaseUIView
    {
        [SerializeField] private Transform m_buildingsElementsRoot = null;

        public Transform GridRoot => m_buildingsElementsRoot;
    }
}
