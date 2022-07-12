using UnityEngine;

namespace Cameras
{
    public class CameraView : MonoBehaviour
    {
        [SerializeField]
        private Camera m_camera = null;
        
        [Space]
        [SerializeField]
        private ECameraId m_cameraId = ECameraId.NONE;


        public Camera Camera => m_camera;
        public ECameraId CameraId => m_cameraId;
    }
}