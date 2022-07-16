using _Scripts.UI.View;
using Cameras;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Building.Impact.Impacts
{
    public class UIBuildingImpactsPanel : BaseUIView
    {
        [SerializeField] private Transform m_impactParent = null;

        public Transform ImpactParent => m_impactParent;

        private Camera m_uiCamera = null;
        private CamerasController m_camerasController = null;
            [Inject]
        public void Construct(
            CamerasController camerasController
            )
        {
            m_camerasController = camerasController;
        }
        
        public void ChangePosition(Transform hudPoint)
        {
            if (m_uiCamera == null)
            {
                m_uiCamera = m_camerasController.GetCamera(ECameraId.GAME).Camera;
            }

            var screenPoint = m_uiCamera.WorldToScreenPoint(hudPoint.position);
            
            m_transform.position = screenPoint;
        }
    }
}